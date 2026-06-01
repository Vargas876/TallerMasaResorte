# Simulador Físico Multimasa: 3 Masas - 4 Resortes - 4 Amortiguadores (Sistema Vertical)

Este es un simulador interactivo de alta fidelidad diseñado para el modelado y la simulación computacional de sistemas vibratorios acoplados verticalmente. El software resuelve las ecuaciones del movimiento tanto en el dominio del tiempo como en el dominio de Laplace ($y(t) \leftrightarrow Y(s)$), automatizando la resolución numérica y simbólica a través de un motor dinámico conectado a **GNU Octave**.

Proyecto final desarrollado para la materia de **Simulación de Computadores** en la **Universidad Pedagógica y Tecnológica de Colombia (UPTC)**.

---

## Autores

* **Julián Velandia**
* **Juan Vargas**

---

## 🛠️ Características Principales

1. **Simulación Combinatoria en Paralelo:**

   * Permite evaluar múltiples combinaciones de constantes de rigidez de resorte ($k$), coeficientes de amortiguamiento ($c$) y masas ($m$) simultáneamente.
   * Genera una tabla interactiva (`DataGridView`) con las métricas clave de cada iteración: elongación pico absoluta por masa (Paso/Impulso) y tiempos de asentamiento.
2. **Doble Gráfica Temporal Optimizada:**

   * Visualización simultánea del comportamiento transitorio ante entrada **Paso** e **Impulso** para las tres masas ($y_1(t), y_2(t), y_3(t)$).
   * Leyendas ubicadas horizontalmente en la parte inferior para maximizar el área de trazado y números de eje formateados con un único decimal para evitar solapamientos.
3. **Animación en Tiempo Real (GDI+):**

   * Lienzo dinámico de alta velocidad pintado mediante gráficos vectoriales vector por vector con doble búfer (`DoubleBuffered`) para evitar parpadeos.
   * Representación detallada del sistema vertical: techo y piso fijos, espirales helicoidales para los resortes, cilindros con pistones para los amortiguadores y vector de fuerza externa $F(t)$ en la masa central $m_2$.
   * Controles de reproducción interactivos: **Iniciar**, **Pausar**, **Reiniciar**, Timeline trackbar (scrubbing) y selector dinámico de respuesta.
4. **Deducción Matemática y Coeficientes Activos:**

   * Muestra las matrices de impedancias y ecuaciones generales del sistema vertical.
   * Resuelve y renderiza en tiempo real las funciones de transferencia numéricas simplificadas $G_1(s)$, $G_2(s)$ y $G_3(s)$ exactas para la iteración seleccionada.

---

## 📈 Formulación Matemática del Sistema

El sistema consta de tres masas verticales acopladas en serie y suspendidas por cuatro resortes y amortiguadores en sus extremos fijos (techo y suelo):

* **Masa 1 ($m_1$):**

  $$
  m_1 \ddot{y}_1(t) + (c_1 + c_2) \dot{y}_1(t) + (k_1 + k_2) y_1(t) - c_2 \dot{y}_2(t) - k_2 y_2(t) = 0
  $$
* **Masa 2 ($m_2$ - Masa Excitada por $F(t)$):**

  $$
  -c_2 \dot{y}_1(t) - k_2 y_1(t) + m_2 \ddot{y}_2(t) + (c_2 + c_3) \dot{y}_2(t) + (k_2 + k_3) y_2(t) - c_3 \dot{y}_3(t) - k_3 y_3(t) = F(t)
  $$
* **Masa 3 ($m_3$):**

  $$
  -c_3 \dot{y}_2(t) - k_3 y_2(t) + m_3 \ddot{y}_3(t) + (c_3 + c_4) \dot{y}_3(t) + (k_3 + k_4) y_3(t) = 0
  $$

### Representación Matricial en Laplace (Condiciones Iniciales Nulas):

$$
\begin{bmatrix}
P_1(s) & -R_{12}(s) & 0 \\
-R_{12}(s) & P_2(s) & -R_{23}(s) \\
0 & -R_{23}(s) & P_3(s)
\end{bmatrix}
\begin{bmatrix}
Y_1(s) \\
Y_2(s) \\
Y_3(s)
\end{bmatrix}
=
\begin{bmatrix}
0 \\
F(s) \\
0
\end{bmatrix}
$$

Donde:

* $P_i(s) = m_i s^2 + (c_i + c_{i+1})s + (k_i + k_{i+1})$ (Impedancias individuales)
* $R_{i,i+1}(s) = c_{i+1}s + k_{i+1}$ (Polinomios de acoplamiento elástico-viscoso)
* Determinante del sistema: $D(s) = P_1(s)P_2(s)P_3(s) - R_{12}(s)^2 P_3(s) - R_{23}(s)^2 P_1(s)$

### Funciones de Transferencia Resultantes:

* **Masa 1 ($m_1$):** $G_1(s) = \frac{Y_1(s)}{F(s)} = \frac{R_{12}(s) P_3(s)}{D(s)}$
* **Masa 2 ($m_2$):** $G_2(s) = \frac{Y_2(s)}{F(s)} = \frac{P_1(s) P_3(s)}{D(s)}$
* **Masa 3 ($m_3$):** $G_3(s) = \frac{Y_3(s)}{F(s)} = \frac{R_{23}(s) P_1(s)}{D(s)}$

---

## Requisitos del Entorno

1. **.NET SDK (.NET Framework 4.8 o superior):**
   * El proyecto se ha migrado a una estructura moderna compatible con `dotnet build` y `dotnet run`.
2. **GNU Octave:**
   * Debe estar instalado localmente (por defecto se busca el ejecutable `octave-cli.exe` en `C:\Program Files\GNU Octave\Octave-11.1.0\mingw64\bin\octave-cli.exe` o posterior, configurable en la GUI).
   * Requiere el paquete **control** de Octave (ya instalado o instalable en Octave con `pkg install -forge control`).

---

## Contenido del Repositorio

* **`Form1.cs` / `Form1.Designer.cs`:** Lógica de negocio y diseño estático/responsivo de la interfaz de usuario en C# Windows Forms.
* **`REPORTE_MATEMATICO.tex`:** Documento de reporte académico redactado en LaTeX utilizando fórmulas vectoriales TikZ para los diagramas mecánicos, listo para compilar a PDF.
* **`TallerMasResorte.csproj`:** Archivo de definición del proyecto .NET en estilo moderno SDK.
