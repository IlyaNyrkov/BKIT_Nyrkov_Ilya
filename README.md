# C# assignments from <img src="https://raw.githubusercontent.com/IlyaNyrkov/IlyaNyrkov/master/bmstu_logo.png" width="35px"> Bauman Moscow State University Course "Base components of internet technologies" on 3rd semester
![](https://img.shields.io/badge/Code-C%23-informational?style=flat&logo=csharp&logoColor=white&color=2bbc8a)
![](https://img.shields.io/badge/Tools-Unity-informational?style=flat&logo=unity&logoColor=white&color=2bbc8a)

# Link to additional info about course https://ugapanyuk.github.io/ </br>
# Assignment list
lab1 <a href="https://github.com/IlyaNyrkov/BKIT_Nyrkov_Ilya/tree/master/lab1">Biquadratic equation solver</a> </br>
lab2 <a href="https://github.com/IlyaNyrkov/BKIT_Nyrkov_Ilya/tree/master/lab2">OOP explained with figures</a> </br>
lab3 <a href="https://github.com/IlyaNyrkov/BKIT_Nyrkov_Ilya/tree/master/lab3">Various collections</a> </br>
lab4 <a href="https://github.com/IlyaNyrkov/BKIT_Nyrkov_Ilya/tree/master/lab4">Delegates and reflection</a> </br>
lab5 <a href="https://github.com/IlyaNyrkov/BKIT_Nyrkov_Ilya/tree/master/lab5">LINQ to objects</a> </br>
homework <a href="https://github.com/IlyaNyrkov/BKIT_Nyrkov_Ilya/tree/master/unity-homework">Simple unity game</a> </br>

# How to build
## On linux
learn how to <a href="https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu">install .Net on Ubuntu</a> </br>
using bash script which builds .exe files and runs it with mono </br>
```
sudo apt install mono-complete
```
## Make file commands

build all labs
```
make build_all
```
build specific lab
```
make build_lab<lab_number>
```
only exception is lab4
```
make build_lab4_pt1
make build_lab4_pt2
```
run lab
```
make run_lab<lab_number>
```
clean executables
```
make clean_all
```
