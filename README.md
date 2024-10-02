# Technology used
C#, WindowsForms, Bitmap, Math, VisualStudio

# Overview
In program I realised 4-dimensional parametric function plotter.

# About project
This project was born as a result of my work in [building n-dimensional cubes](https://github.com/LordSerg/Dimensions) and [building user input function](https://github.com/LordSerg/Functions).

Having in hands these technologies I've come to the idea of multidimensional functions, that can be rotated.

## Program example
Here is the default function for demonstration:
![]()

Here is some user-input-function:
![]()


## Brief math explanation
### Rotation
In this program there is only 4th dimension space, so any rotation can be explained using combination of these 6 matrices:

$$
\begin{align}
\left( \begin{matrix}
1 & 0 & 0 & 0 \\
0 & 1 & 0 & 0 \\
0 & 0 & \cos\alpha & -\sin\alpha \\
0 & 0 & \sin\alpha & \cos\alpha \\
\end{matrix} \right) & \left( \begin{matrix}
1 & 0 & 0 & 0 \\
0 & \cos\beta & 0 & \sin\beta \\
0 & 0 & 1 & 0 \\
0 & -\sin\beta & 0 & \cos\beta \\
\end{matrix} \right) \\
\left( \begin{matrix}
1 & 0 & 0 & 0 \\
0 & \cos\gamma & -\sin\gamma & 0 \\
0 & \sin\gamma & \cos\gamma & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix} \right) & \left( \begin{matrix}
\cos\delta & 0 & 0 & -\sin\delta \\
0 & 1 & 0 & 0 \\
0 & 0 & 1 & 0 \\
\sin\delta & 0 & 0 & \cos\delta \\
\end{matrix} \right) \\
\left( \begin{matrix}
\cos\eta & 0 & \sin\eta & 0 \\
0 & 1 & 0 & 0 \\
-\sin\eta & 0 & \cos\eta & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix} \right) & \left( \begin{matrix}
\cos\omega & -\sin\omega & 0 & 0 \\
\sin\omega & \cos\omega & 0 & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix} \right)
\end{align}
$$

where $\alpha$, $\beta$, $\gamma$, $\delta$, $\eta$ and $\omega$ are angles of rotation.

To rotate any point **p**

$$
p=\left( \begin{matrix}
x \\
y \\
z \\
w \\
\end{matrix} \right)
$$

around the origin in specific angle - just multiply specific matrix on the point and voila - you have a new position of the point **p**.

### Reading function
Here were used the same technique as [here](https://github.com/LordSerg/Functions) - read function, classify every function as an index and build an expression tree like this:

![expression tree](https://miro.medium.com/v2/resize:fit:640/format:webp/1*5wq2bufZk-dMmCAB-nYlFA.png)

Then to calculate result - insert needed number instead of **x** and calculate the tree from leaves to the root!
