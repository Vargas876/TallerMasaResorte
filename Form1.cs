using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Octave.NET;

namespace TallerMasResorte
{
    public partial class SpringMassForm : Form
    {

        public class SimulationIteration
        {
            public int Index { get; set; }
            public double M1 { get; set; }
            public double M2 { get; set; }
            public double M3 { get; set; }
            public double K1 { get; set; }
            public double K2 { get; set; }
            public double K3 { get; set; }
            public double K4 { get; set; }
            public double C1 { get; set; }
            public double C2 { get; set; }
            public double C3 { get; set; }
            public double C4 { get; set; }

            public double[] StepT { get; set; }
            public double[] StepY1 { get; set; }
            public double[] StepY2 { get; set; }
            public double[] StepY3 { get; set; }


            public double[] ImpulseT { get; set; }
            public double[] ImpulseY1 { get; set; }
            public double[] ImpulseY2 { get; set; }
            public double[] ImpulseY3 { get; set; }

    
            public double StepPeakM1 { get; set; }
            public double StepPeakM2 { get; set; }
            public double StepPeakM3 { get; set; }

            public double ImpulsePeakM1 { get; set; }
            public double ImpulsePeakM2 { get; set; }
            public double ImpulsePeakM3 { get; set; }

            public double StepDuration { get; set; }
            public double ImpulseDuration { get; set; }
        }

        private List<SimulationIteration> results = new List<SimulationIteration>();
        private SimulationIteration selectedIteration = null;

        private int animationIndex = 0;
        private bool isStepAnimation = true;
        private bool isUpdatingSlider = false;



        public SpringMassForm()
        {
            InitializeComponent();
            var doubleBufferProp = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            doubleBufferProp.SetValue(this.picCanvas, true, null);

            // Inicializar índices predeterminados para evitar variables nulas en el diseñador
            cbVaryK.SelectedIndex = 0;
            cbVaryC.SelectedIndex = 1;
            cbVaryM.SelectedIndex = 2;
            cbAnimType.SelectedIndex = 0;
        }

        private async void btnSimulate_Click(object sender, EventArgs e)
        {
            results.Clear();
            dgvResults.Rows.Clear();
            timer1.Stop();
            btnPlayPause.Text = "Iniciar";
            selectedIteration = null;
            if (!ValidateInputs()) return;

            string octaveCliPath = txtOctavePath.Text.Trim();
            int numPoints = int.Parse(txtElements.Text);

            double baseM1 = double.Parse(txtM1.Text);
            double baseM2 = double.Parse(txtM2.Text);
            double baseM3 = double.Parse(txtM3.Text);
            double baseK1 = double.Parse(txtK1.Text);
            double baseK2 = double.Parse(txtK2.Text);
            double baseK3 = double.Parse(txtK3.Text);
            double baseK4 = double.Parse(txtK4.Text);
            double baseC1 = double.Parse(txtC1.Text);
            double baseC2 = double.Parse(txtC2.Text);
            double baseC3 = double.Parse(txtC3.Text);
            double baseC4 = double.Parse(txtC4.Text);

            string varyKLabel = cbVaryK.Text;
            string varyCLabel = cbVaryC.Text;
            string varyMLabel = cbVaryM.Text;

            List<double> kRange = GenerateRange(txtKMin.Text, txtKMax.Text, txtKStep.Text);
            List<double> cRange = GenerateRange(txtCMin.Text, txtCMax.Text, txtCStep.Text);
            List<double> mRange = GenerateRange(txtMMin.Text, txtMMax.Text, txtMStep.Text);

            int totalCombinations = kRange.Count * cRange.Count * mRange.Count;

            btnSimulate.Enabled = false;
            progressBarSim.Visible = true;
            progressBarSim.Minimum = 0;
            progressBarSim.Maximum = totalCombinations;
            progressBarSim.Value = 0;
            lblSimStatus.Text = $"Preparando {totalCombinations} combinaciones de simulación...";

            OctaveContext.OctaveSettings.OctaveCliPath = octaveCliPath;

            await Task.Run(() =>
            {
                int currentComb = 0;
                var octave = new OctaveContext();

                foreach (double kv in kRange)
                {
                    foreach (double cv in cRange)
                    {
                        foreach (double mv in mRange)
                        {
                            currentComb++;
                            var iter = new SimulationIteration
                            {
                                Index = currentComb,
                                M1 = baseM1,
                                M2 = baseM2,
                                M3 = baseM3,
                                K1 = baseK1,
                                K2 = baseK2,
                                K3 = baseK3,
                                K4 = baseK4,
                                C1 = baseC1,
                                C2 = baseC2,
                                C3 = baseC3,
                                C4 = baseC4
                            };

                            AssignVariedValue(iter, varyKLabel, kv);
                            AssignVariedValue(iter, varyCLabel, cv);
                            AssignVariedValue(iter, varyMLabel, mv);

                            SimulateIterationInOctave(octave, iter, numPoints);

                            iter.StepPeakM1 = iter.StepY1.Max(Math.Abs);
                            iter.StepPeakM2 = iter.StepY2.Max(Math.Abs);
                            iter.StepPeakM3 = iter.StepY3.Max(Math.Abs);

                            iter.ImpulsePeakM1 = iter.ImpulseY1.Max(Math.Abs);
                            iter.ImpulsePeakM2 = iter.ImpulseY2.Max(Math.Abs);
                            iter.ImpulsePeakM3 = iter.ImpulseY3.Max(Math.Abs);

                            iter.StepDuration = iter.StepT.Last();
                            iter.ImpulseDuration = iter.ImpulseT.Last();

                            results.Add(iter);

                            this.Invoke((MethodInvoker)delegate
                            {
                                progressBarSim.Value = currentComb;
                                lblSimStatus.Text = $"Simulando iteración {currentComb} de {totalCombinations}...";
                            });
                        }
                    }
                }
            });

            btnSimulate.Enabled = true;
            progressBarSim.Visible = false;
            lblSimStatus.Text = "Simulación combinatoria completada con éxito";

            foreach (var iter in results)
            {
                string varKInfo = $"{cbVaryK.Text} = {GetVariedValue(iter, cbVaryK.Text):F1}";
                string varCInfo = $"{cbVaryC.Text} = {GetVariedValue(iter, cbVaryC.Text):F1}";
                string varMInfo = $"{cbVaryM.Text} = {GetVariedValue(iter, cbVaryM.Text):F1}";

                string peaksStep = $"({iter.StepPeakM1:F3} / {iter.StepPeakM2:F3} / {iter.StepPeakM3:F3})";
                string peaksImpulse = $"({iter.ImpulsePeakM1:F3} / {iter.ImpulsePeakM2:F3} / {iter.ImpulsePeakM3:F3})";

                dgvResults.Rows.Add(
                    iter.Index,
                    varKInfo,
                    varCInfo,
                    varMInfo,
                    peaksStep,
                    peaksImpulse,
                    $"{iter.StepDuration:F2} s",
                    $"{iter.ImpulseDuration:F2} s"
                );
            }

            lblResultsSummary.Text = $"Simulaciones ejecutadas: {totalCombinations}. Seleccione una fila para cargar sus gráficas y animación.";
            
            if (dgvResults.Rows.Count > 0)
            {
                dgvResults.Rows[0].Selected = true;
            }
        }

        private void SimulateIterationInOctave(OctaveContext octave, SimulationIteration iter, int elements)
        {
            string script = "pkg load control;\n" +
                            "s = tf('s');\n" +
                            $"m1={iter.M1}; m2={iter.M2}; m3={iter.M3};\n" +
                            $"k1={iter.K1}; k2={iter.K2}; k3={iter.K3}; k4={iter.K4};\n" +
                            $"c1={iter.C1}; c2={iter.C2}; c3={iter.C3}; c4={iter.C4};\n" +
                            "P1 = m1*s^2 + (c1 + c2)*s + (k1 + k2);\n" +
                            "P2 = m2*s^2 + (c2 + c3)*s + (k2 + k3);\n" +
                            "P3 = m3*s^2 + (c3 + c4)*s + (k3 + k4);\n" +
                            "R12 = c2*s + k2;\n" +
                            "R23 = c3*s + k3;\n" +
                            "D = P1*P2*P3 - (R12^2)*P3 - (R23^2)*P1;\n" +
                            "G1 = R12 * P3 / D;\n" +
                            "G2 = P1 * P3 / D;\n" +
                            "G3 = R23 * P1 / D;\n" +
                            "[y1, t1] = step(G1);\n" +
                            "[y2, t2] = step(G2);\n" +
                            "[y3, t3] = step(G3);\n" +
                            "[yi1, ti1] = impulse(G1);\n" +
                            "[yi2, ti2] = impulse(G2);\n" +
                            "[yi3, ti3] = impulse(G3);\n" +
                            "t_final_step = max([t1(end), t2(end), t3(end)]);\n" +
                            "t_final_impulse = max([ti1(end), ti2(end), ti3(end)]);\n" +
                            $"t_step = linspace(0, t_final_step, {elements});\n" +
                            $"t_impulse = linspace(0, t_final_impulse, {elements});\n" +
                            "[y1, t_step] = step(G1, t_step);\n" +
                            "[y2, t_step] = step(G2, t_step);\n" +
                            "[y3, t_step] = step(G3, t_step);\n" +
                            "[yi1, t_impulse] = impulse(G1, t_impulse);\n" +
                            "[yi2, t_impulse] = impulse(G2, t_impulse);\n" +
                            "[yi3, t_impulse] = impulse(G3, t_impulse);\n" +
                            "y1=y1(:); y2=y2(:); y3=y3(:); t_step=t_step(:);\n" +
                            "yi1=yi1(:); yi2=yi2(:); yi3=yi3(:); t_impulse=t_impulse(:);\n";

            octave.Execute(script);

            iter.StepT = octave.Execute("t_step").AsVector();
            iter.StepY1 = octave.Execute("y1").AsVector();
            iter.StepY2 = octave.Execute("y2").AsVector();
            iter.StepY3 = octave.Execute("y3").AsVector();

            iter.ImpulseT = octave.Execute("t_impulse").AsVector();
            iter.ImpulseY1 = octave.Execute("yi1").AsVector();
            iter.ImpulseY2 = octave.Execute("yi2").AsVector();
            iter.ImpulseY3 = octave.Execute("yi3").AsVector();
        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0 || results.Count == 0) return;

            int selectedIndex = Convert.ToInt32(dgvResults.SelectedRows[0].Cells[0].Value) - 1;
            selectedIteration = results[selectedIndex];

            PlotResponseCurves();

            DisplayNumericalMathEquations();

            animationIndex = 0;
            trackBarTime.Maximum = selectedIteration.StepT.Length - 1;
            trackBarTime.Value = 0;
            timer1.Start();
            btnPlayPause.Text = "Pausar";
            btnPlayPause.BackColor = Color.FromArgb(231, 76, 60);
            
            UpdateChartCursors(0);

            picCanvas.Invalidate();
        }

        private void UpdateChartCursors(double t)
        {
            if (selectedIteration == null) return;

            chartStep.Annotations.Clear();
            chartImpulse.Annotations.Clear();

            if (isStepAnimation)
            {
                var stepLine = new VerticalLineAnnotation
                {
                    AxisX = chartStep.ChartAreas[0].AxisX,
                    AllowMoving = false,
                    IsInfinitive = true,
                    ClipToChartArea = "MainArea",
                    LineColor = Color.FromArgb(231, 76, 60), 
                    LineWidth = 2,
                    LineDashStyle = ChartDashStyle.Dash,
                    X = t
                };
                chartStep.Annotations.Add(stepLine);
            }
            else
            {
                var impulseLine = new VerticalLineAnnotation
                {
                    AxisX = chartImpulse.ChartAreas[0].AxisX,
                    AllowMoving = false,
                    IsInfinitive = true,
                    ClipToChartArea = "MainArea",
                    LineColor = Color.FromArgb(231, 76, 60),
                    LineWidth = 2,
                    LineDashStyle = ChartDashStyle.Dash,
                    X = t
                };
                chartImpulse.Annotations.Add(impulseLine);
            }
        }

        private void PlotResponseCurves()
        {
            if (selectedIteration == null) return;
            chartStep.Series.Clear();
            var stepSeries1 = new Series("y1(t) - Masa 1") { ChartType = SeriesChartType.Line, BorderWidth = 3, Color = Color.FromArgb(41, 128, 185) };
            var stepSeries2 = new Series("y2(t) - Masa 2") { ChartType = SeriesChartType.Line, BorderWidth = 3, Color = Color.FromArgb(39, 174, 96) };
            var stepSeries3 = new Series("y3(t) - Masa 3") { ChartType = SeriesChartType.Line, BorderWidth = 3, Color = Color.FromArgb(243, 156, 18) };

            for (int i = 0; i < selectedIteration.StepT.Length; i++)
            {
                stepSeries1.Points.AddXY(selectedIteration.StepT[i], selectedIteration.StepY1[i]);
                stepSeries2.Points.AddXY(selectedIteration.StepT[i], selectedIteration.StepY2[i]);
                stepSeries3.Points.AddXY(selectedIteration.StepT[i], selectedIteration.StepY3[i]);
            }
            chartStep.Series.Add(stepSeries1);
            chartStep.Series.Add(stepSeries2);
            chartStep.Series.Add(stepSeries3);

            chartImpulse.Series.Clear();
            var impSeries1 = new Series("y1(t) - Masa 1") { ChartType = SeriesChartType.Line, BorderWidth = 3, Color = Color.FromArgb(41, 128, 185) };
            var impSeries2 = new Series("y2(t) - Masa 2") { ChartType = SeriesChartType.Line, BorderWidth = 3, Color = Color.FromArgb(39, 174, 96) };
            var impSeries3 = new Series("y3(t) - Masa 3") { ChartType = SeriesChartType.Line, BorderWidth = 3, Color = Color.FromArgb(243, 156, 18) };

            for (int i = 0; i < selectedIteration.ImpulseT.Length; i++)
            {
                impSeries1.Points.AddXY(selectedIteration.ImpulseT[i], selectedIteration.ImpulseY1[i]);
                impSeries2.Points.AddXY(selectedIteration.ImpulseT[i], selectedIteration.ImpulseY2[i]);
                impSeries3.Points.AddXY(selectedIteration.ImpulseT[i], selectedIteration.ImpulseY3[i]);
            }
            chartImpulse.Series.Add(impSeries1);
            chartImpulse.Series.Add(impSeries2);
            chartImpulse.Series.Add(impSeries3);
        }

        private void DisplayNumericalMathEquations()
        {
            if (selectedIteration == null) return;

            rtbMath.Clear();
            rtbMath.SelectionFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            rtbMath.SelectionColor = Color.FromArgb(41, 128, 185);
            rtbMath.AppendText($"ECUACIONES NUMÉRICAS PARA LA ITERACIÓN #{selectedIteration.Index}\n\n");

            rtbMath.SelectionFont = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            rtbMath.SelectionColor = Color.Black;
            rtbMath.AppendText("Constantes Asignadas:\n");
            rtbMath.SelectionFont = new Font("Consolas", 10F);
            rtbMath.SelectionColor = Color.FromArgb(44, 62, 80);
            rtbMath.AppendText($"  Masas: m1 = {selectedIteration.M1} kg, m2 = {selectedIteration.M2} kg, m3 = {selectedIteration.M3} kg\n");
            rtbMath.AppendText($"  Resortes: k1 = {selectedIteration.K1} N/m, k2 = {selectedIteration.K2} N/m, k3 = {selectedIteration.K3} N/m, k4 = {selectedIteration.K4} N/m\n");
            rtbMath.AppendText($"  Amortiguadores: c1 = {selectedIteration.C1} Ns/m, c2 = {selectedIteration.C2} Ns/m, c3 = {selectedIteration.C3} Ns/m, c4 = {selectedIteration.C4} Ns/m\n\n");

            rtbMath.SelectionFont = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            rtbMath.SelectionColor = Color.Black;
            rtbMath.AppendText("Modelado Físico Resultante (Polinomios de Laplace):\n");
            rtbMath.SelectionFont = new Font("Consolas", 10F);
            rtbMath.SelectionColor = Color.FromArgb(44, 62, 80);
            
            double p1_s2 = selectedIteration.M1;
            double p1_s1 = selectedIteration.C1 + selectedIteration.C2;
            double p1_s0 = selectedIteration.K1 + selectedIteration.K2;

            double p2_s2 = selectedIteration.M2;
            double p2_s1 = selectedIteration.C2 + selectedIteration.C3;
            double p2_s0 = selectedIteration.K2 + selectedIteration.K3;

            double p3_s2 = selectedIteration.M3;
            double p3_s1 = selectedIteration.C3 + selectedIteration.C4;
            double p3_s0 = selectedIteration.K3 + selectedIteration.K4;

            rtbMath.AppendText($"  P1(s)  = {p1_s2}*s^2 + {p1_s1}*s + {p1_s0}\n");
            rtbMath.AppendText($"  P2(s)  = {p2_s2}*s^2 + {p2_s1}*s + {p2_s0}\n");
            rtbMath.AppendText($"  P3(s)  = {p3_s2}*s^2 + {p3_s1}*s + {p3_s0}\n");
            rtbMath.AppendText($"  R12(s) = {selectedIteration.C2}*s + {selectedIteration.K2}\n");
            rtbMath.AppendText($"  R23(s) = {selectedIteration.C3}*s + {selectedIteration.K3}\n\n");

            var octave = new OctaveContext();
            string evalScript = "pkg load control;\n" +
                                "s = tf('s');\n" +
                                $"m1={selectedIteration.M1}; m2={selectedIteration.M2}; m3={selectedIteration.M3};\n" +
                                $"k1={selectedIteration.K1}; k2={selectedIteration.K2}; k3={selectedIteration.K3}; k4={selectedIteration.K4};\n" +
                                $"c1={selectedIteration.C1}; c2={selectedIteration.C2}; c3={selectedIteration.C3}; c4={selectedIteration.C4};\n" +
                                "P1 = m1*s^2 + (c1 + c2)*s + (k1 + k2);\n" +
                                "P2 = m2*s^2 + (c2 + c3)*s + (k2 + k3);\n" +
                                "P3 = m3*s^2 + (c3 + c4)*s + (k3 + k4);\n" +
                                "R12 = c2*s + k2;\n" +
                                "R23 = c3*s + k3;\n" +
                                "D = P1*P2*P3 - (R12^2)*P3 - (R23^2)*P1;\n" +
                                "G1 = R12 * P3 / D;\n" +
                                "G2 = P1 * P3 / D;\n" +
                                "G3 = R23 * P1 / D;\n";
            octave.Execute(evalScript);

            string g1Text = octave.Execute("G1").ToString();
            string g2Text = octave.Execute("G2").ToString();
            string g3Text = octave.Execute("G3").ToString();

            rtbMath.SelectionFont = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            rtbMath.SelectionColor = Color.Black;
            rtbMath.AppendText("Funciones de Transferencia algebraicas (G(S)) en base a coeficientes reales:\n\n");

            rtbMath.SelectionFont = new Font("Consolas", 10F, FontStyle.Bold);
            rtbMath.SelectionColor = Color.FromArgb(142, 68, 173);
            rtbMath.AppendText("G1(s) = Y1(s)/F(s):\n" + g1Text + "\n\n");
            rtbMath.AppendText("G2(s) = Y2(s)/F(s):\n" + g2Text + "\n\n");
            rtbMath.AppendText("G3(s) = Y3(s)/F(s):\n" + g3Text + "\n");
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (selectedIteration == null) return;

            if (timer1.Enabled)
            {
                timer1.Stop();
                btnPlayPause.Text = "Iniciar";
                btnPlayPause.BackColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                timer1.Start();
                btnPlayPause.Text = "Pausar";
                btnPlayPause.BackColor = Color.FromArgb(231, 76, 60);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (selectedIteration == null) return;

            animationIndex = 0;
            trackBarTime.Value = 0;
            picCanvas.Invalidate();
            
            double totalT = isStepAnimation ? selectedIteration.StepDuration : selectedIteration.ImpulseDuration;
            lblTime.Text = $"Tiempo: 0,00 s /\n{totalT:F2} s";

            UpdateChartCursors(0);
        }

        private void trackBarTime_Scroll(object sender, EventArgs e)
        {
            if (selectedIteration == null || isUpdatingSlider) return;

            animationIndex = trackBarTime.Value;
            picCanvas.Invalidate();

            double t = isStepAnimation ? selectedIteration.StepT[animationIndex] : selectedIteration.ImpulseT[animationIndex];
            double totalT = isStepAnimation ? selectedIteration.StepDuration : selectedIteration.ImpulseDuration;
            lblTime.Text = $"Tiempo: {t:F2} s /\n{totalT:F2} s";

            UpdateChartCursors(t);
        }

        private void cbAnimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            isStepAnimation = (cbAnimType.SelectedIndex == 0);
            btnReset_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (selectedIteration == null) return;

            int length = isStepAnimation ? selectedIteration.StepT.Length : selectedIteration.ImpulseT.Length;

            if (animationIndex >= length)
            {
                animationIndex = 0;
            }

            isUpdatingSlider = true;
            trackBarTime.Value = animationIndex;
            isUpdatingSlider = false;

            picCanvas.Invalidate();

            double t = isStepAnimation ? selectedIteration.StepT[animationIndex] : selectedIteration.ImpulseT[animationIndex];
            double totalT = isStepAnimation ? selectedIteration.StepDuration : selectedIteration.ImpulseDuration;
            lblTime.Text = $"Tiempo: {t:F2} s /\n{totalT:F2} s";

            UpdateChartCursors(t);

            animationIndex++;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (selectedIteration == null)
            {
                DrawSystemState(e.Graphics, 0, 0, 0);
                return;
            }

            int idx = animationIndex;
            int length = isStepAnimation ? selectedIteration.StepT.Length : selectedIteration.ImpulseT.Length;
            if (idx >= length) idx = length - 1;
            if (idx < 0) idx = 0;

            double x1 = isStepAnimation ? selectedIteration.StepY1[idx] : selectedIteration.ImpulseY1[idx];
            double x2 = isStepAnimation ? selectedIteration.StepY2[idx] : selectedIteration.ImpulseY2[idx];
            double x3 = isStepAnimation ? selectedIteration.StepY3[idx] : selectedIteration.ImpulseY3[idx];

            DrawSystemState(e.Graphics, x1, x2, x3);
        }

        private void DrawSystemState(Graphics g, double x1, double x2, double x3)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(248, 249, 250));

            int W = picCanvas.Width;
            int H = picCanvas.Height;
            float X = W / 2f;

            float yCeiling = 50f;
            float yFloor = H - 50f;

            float totalGap = yFloor - yCeiling;
            float hGap = totalGap / 4f;

            float y1Rest = yCeiling + hGap;
            float y2Rest = yCeiling + 2 * hGap;
            float y3Rest = yCeiling + 3 * hGap;

            float scaleFactor = 100f;
            float.TryParse(txtScaleFactor.Text, out scaleFactor);

            float y1 = (float)(y1Rest + x1 * scaleFactor);
            float y2 = (float)(y2Rest + x2 * scaleFactor);
            float y3 = (float)(y3Rest + x3 * scaleFactor);

            if (y1 < yCeiling + 30) y1 = yCeiling + 30;
            if (y2 < y1 + 30) y2 = y1 + 30;
            if (y3 < y2 + 30) y3 = y2 + 30;
            if (y3 > yFloor - 30) y3 = yFloor - 30;

            Pen penFixed = new Pen(Color.FromArgb(44, 62, 80), 3f);
            Pen penDrawn = new Pen(Color.FromArgb(44, 62, 80), 2f);
            Pen penSpring = new Pen(Color.FromArgb(230, 126, 34), 2.2f);
            Pen penDamper = new Pen(Color.FromArgb(52, 152, 219), 2.2f);
            Pen penForce = new Pen(Color.FromArgb(231, 76, 60), 3.5f);

            // Ceiling line (ancho óptimo y balanceado)
            g.DrawLine(penFixed, X - 150, yCeiling, X + 150, yCeiling);
            for (int i = -7; i <= 7; i++)
            {
                g.DrawLine(penDrawn, X + i * 20, yCeiling, X + i * 20 + 8, yCeiling - 8);
            }

            // Floor line (ancho óptimo y balanceado)
            g.DrawLine(penFixed, X - 150, yFloor, X + 150, yFloor);
            for (int i = -7; i <= 7; i++)
            {
                g.DrawLine(penDrawn, X + i * 20, yFloor, X + i * 20 - 8, yFloor + 8);
            }

            float mWidth = 140f; // Ancho intermedio perfecto
            float mHeight = 46f; // Altura intermedia perfecta

            DrawSpring(g, penSpring, X - 45, yCeiling, y1 - mHeight/2);
            DrawDamper(g, penDamper, X + 45, yCeiling, y1 - mHeight/2);

            DrawSpring(g, penSpring, X - 45, y1 + mHeight/2, y2 - mHeight/2);
            DrawDamper(g, penDamper, X + 45, y1 + mHeight/2, y2 - mHeight/2);

            DrawSpring(g, penSpring, X - 45, y2 + mHeight/2, y3 - mHeight/2);
            DrawDamper(g, penDamper, X + 45, y2 + mHeight/2, y3 - mHeight/2);

            DrawSpring(g, penSpring, X - 45, y3 + mHeight/2, yFloor);
            DrawDamper(g, penDamper, X + 45, y3 + mHeight/2, yFloor);

          
            RectangleF rect1 = new RectangleF(X - mWidth/2, y1 - mHeight/2, mWidth, mHeight);
            using (var lgb = new LinearGradientBrush(rect1, Color.FromArgb(41, 128, 185), Color.FromArgb(52, 152, 219), 45f))
                g.FillRectangle(lgb, rect1);
            g.DrawRectangle(penFixed, X - mWidth/2, y1 - mHeight/2, mWidth, mHeight);

            RectangleF rect2 = new RectangleF(X - mWidth/2, y2 - mHeight/2, mWidth, mHeight);
            using (var lgb = new LinearGradientBrush(rect2, Color.FromArgb(39, 174, 96), Color.FromArgb(46, 204, 113), 45f))
                g.FillRectangle(lgb, rect2);
            g.DrawRectangle(penFixed, X - mWidth/2, y2 - mHeight/2, mWidth, mHeight);

            RectangleF rect3 = new RectangleF(X - mWidth/2, y3 - mHeight/2, mWidth, mHeight);
            using (var lgb = new LinearGradientBrush(rect3, Color.FromArgb(243, 156, 18), Color.FromArgb(241, 196, 15), 45f))
                g.FillRectangle(lgb, rect3);
            g.DrawRectangle(penFixed, X - mWidth/2, y3 - mHeight/2, mWidth, mHeight);

            using (Font f = new Font("Segoe UI", 9F, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.White))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString($"m1 = {txtM1.Text} kg\ny1: {x1:F3}", f, b, rect1, sf);
                g.DrawString($"m2 = {txtM2.Text} kg\ny2: {x2:F3}", f, b, rect2, sf);
                g.DrawString($"m3 = {txtM3.Text} kg\ny3: {x3:F3}", f, b, rect3, sf);
            }

            float arrowX = X - mWidth/2 - 25;
            float arrowStart = y2 - 25;
            float arrowEnd = y2 + 15;
            g.DrawLine(penForce, arrowX, arrowStart, arrowX, arrowEnd);
            g.DrawLine(penForce, arrowX, arrowEnd, arrowX - 5, arrowEnd - 5);
            g.DrawLine(penForce, arrowX, arrowEnd, arrowX + 5, arrowEnd - 5);
            using (Font fForce = new Font("Segoe UI", 9F, FontStyle.Bold))
            {
                g.DrawString("f(t)", fForce, Brushes.Red, arrowX - 25, y2 - 10);
            }
        }

        private void DrawSpring(Graphics g, Pen pen, float x, float yStart, float yEnd)
        {
            float length = yEnd - yStart;
            int turns = 8;
            float startEndGap = 10f;
            float coilHeight = length - 2 * startEndGap;

            g.DrawLine(pen, x, yStart, x, yStart + startEndGap);

            float turnHeight = coilHeight / (turns * 2);
            float width = 12f;
            float currY = yStart + startEndGap;

            var points = new List<PointF> { new PointF(x, currY) };
            for (int i = 1; i <= turns * 2; i++)
            {
                float dir = (i % 2 == 0) ? -1f : 1f;
                currY += turnHeight;
                points.Add(new PointF(x + dir * width, currY));
            }
            points.Add(new PointF(x, yEnd - startEndGap));

            g.DrawLines(pen, points.ToArray());
            g.DrawLine(pen, x, yEnd - startEndGap, x, yEnd);
        }

        private void DrawDamper(Graphics g, Pen pen, float x, float yStart, float yEnd)
        {
            float length = yEnd - yStart;
            float pistonPos = yStart + length * 0.35f;
            float cylinderBottom = yEnd - 10f;

           
            g.DrawLine(pen, x, yStart, x, pistonPos);
            g.DrawLine(new Pen(pen.Color, 3), x - 7, pistonPos, x + 7, pistonPos);        
            g.DrawLine(pen, x, cylinderBottom, x, yEnd);
            g.DrawLine(pen, x - 11, pistonPos - 5, x - 11, cylinderBottom);
            g.DrawLine(pen, x + 11, pistonPos - 5, x + 11, cylinderBottom);
            g.DrawLine(pen, x - 11, cylinderBottom, x + 11, cylinderBottom);
        }

     
        private void AssignVariedValue(SimulationIteration iter, string label, double val)
        {
            switch (label)
            {
                case "k1": iter.K1 = val; break;
                case "k2": iter.K2 = val; break;
                case "k3": iter.K3 = val; break;
                case "k4": iter.K4 = val; break;
                case "c1": iter.C1 = val; break;
                case "c2": iter.C2 = val; break;
                case "c3": iter.C3 = val; break;
                case "c4": iter.C4 = val; break;
                case "m1": iter.M1 = val; break;
                case "m2": iter.M2 = val; break;
                case "m3": iter.M3 = val; break;
            }
        }

        private double GetVariedValue(SimulationIteration iter, string label)
        {
            switch (label)
            {
                case "k1": return iter.K1;
                case "k2": return iter.K2;
                case "k3": return iter.K3;
                case "k4": return iter.K4;
                case "c1": return iter.C1;
                case "c2": return iter.C2;
                case "c3": return iter.C3;
                case "c4": return iter.C4;
                case "m1": return iter.M1;
                case "m2": return iter.M2;
                case "m3": return iter.M3;
                default: return 0.0;
            }
        }

        private List<double> GenerateRange(string minText, string maxText, string stepText)
        {
            double min = double.Parse(minText);
            double max = double.Parse(maxText);
            double step = double.Parse(stepText);

            var list = new List<double>();
            for (double val = min; val <= max + 0.0001; val += step)
            {
                list.Add(val);
            }
            return list;
        }

       
        private bool ValidateInputs()
        {
            
            Control[] basicFields = new Control[] { 
                txtM1, txtM2, txtM3, txtK1, txtK2, txtK3, txtK4, txtC1, txtC2, txtC3, txtC4,
                txtKMin, txtKMax, txtKStep, txtCMin, txtCMax, txtCStep, txtMMin, txtMMax, txtMStep,
                txtElements, txtScaleFactor, txtOctavePath
            };

            foreach (var ctrl in basicFields)
            {
                if (string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    MessageBox.Show("Todos los campos numéricos y de ruta son obligatorios. Verifique que no queden celdas vacías.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            try
            {
                double m1 = double.Parse(txtM1.Text);
                double m2 = double.Parse(txtM2.Text);
                double m3 = double.Parse(txtM3.Text);

                double k1 = double.Parse(txtK1.Text);
                double k2 = double.Parse(txtK2.Text);
                double k3 = double.Parse(txtK3.Text);
                double k4 = double.Parse(txtK4.Text);

                double c1 = double.Parse(txtC1.Text);
                double c2 = double.Parse(txtC2.Text);
                double c3 = double.Parse(txtC3.Text);
                double c4 = double.Parse(txtC4.Text);

                int elements = int.Parse(txtElements.Text);
                int scale = int.Parse(txtScaleFactor.Text);

               
                if (m1 <= 0 || m2 <= 0 || m3 <= 0)
                {
                    MessageBox.Show("Las masas m1, m2 y m3 deben ser estrictamente positivas (mayores a cero).", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

             
                if (k1 <= 0 || k2 <= 0 || k3 <= 0 || k4 <= 0)
                {
                    MessageBox.Show("Las constantes de rigidez de resorte k deben ser estrictamente positivas (mayores a cero).", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                
                if (c1 < 0 || c2 < 0 || c3 < 0 || c4 < 0)
                {
                    MessageBox.Show("Los coeficientes de amortiguamiento c no pueden ser negativos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                
                if (elements <= 10)
                {
                    MessageBox.Show("El número de puntos de simulación debe ser mayor a 10 para garantizar la resolución gráfica.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

               
                double kMin = double.Parse(txtKMin.Text);
                double kMax = double.Parse(txtKMax.Text);
                double kStep = double.Parse(txtKStep.Text);

                double cMin = double.Parse(txtCMin.Text);
                double cMax = double.Parse(txtCMax.Text);
                double cStep = double.Parse(txtCStep.Text);

                double mMin = double.Parse(txtMMin.Text);
                double mMax = double.Parse(txtMMax.Text);
                double mStep = double.Parse(txtMStep.Text);

             
                if (kStep <= 0 || cStep <= 0 || mStep <= 0)
                {
                    MessageBox.Show("El tamaño de paso de los rangos debe ser estrictamente mayor a cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

              
                if (kMax < kMin || cMax < cMin || mMax < mMin)
                {
                    MessageBox.Show("El límite superior de un rango variable no puede ser menor al límite inferior.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                
                if (kMin <= 0 || mMin <= 0)
                {
                    MessageBox.Show("Las constantes variables de rigidez y masa deben ser estrictamente mayores a cero en todo su rango.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cMin < 0)
                {
                    MessageBox.Show("Las constantes variables de amortiguamiento no pueden ser negativas en su rango.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique que todos los campos numéricos contengan valores reales o enteros válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string path = txtOctavePath.Text.Trim();
            if (!File.Exists(path))
            {
                MessageBox.Show($"No se encontró el ejecutable de GNU Octave en la ruta especificada:\n'{path}'\n\nPor favor, corrija la ruta antes de iniciar la simulación.", "Octave CLI No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SpringMassForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
