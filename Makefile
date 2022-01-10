# lab1
build_lab1:
	mcs -out:lab1.exe lab1/Program.cs

run_lab1:
	mono lab1.exe

clean_lab1:
	rm lab1.exe

# lab2
build_lab2:
	mcs -out:lab2.exe lab2/Program.cs

run_lab2:
	mono lab2.exe

clean_lab2:
	rm lab2.exe

# lab3
build_lab3:
	mcs -out:lab3.exe lab3/Program.cs

run_lab3:
	mono lab3.exe

clean_lab3:
	rm lab3.exe

# lab4 pt 1
build_lab4_pt1:
	mcs -out:lab4_pt1.exe lab4/Program_pt1.cs

run_lab4_pt1:
	mono lab4_pt1.exe

clean_lab4_pt1:
	rm lab4_pt1.exe

# lab4 pt 2
build_lab4_pt2:
	mcs -out:lab4_pt2.exe lab4/Program_pt2.cs

run_lab4_pt2:
	mono lab4_pt2.exe

clean_lab4_pt2:
	rm lab4_pt2.exe

# lab5
build_lab5:
	mcs -out:lab5.exe lab5/Program.cs

run_lab5:
	mono lab5.exe

clean_lab5:
	rm lab5.exe

# special rule used to run dependency if previous failes
# usage -<something>, where something is dependency
-%:
	-@$(MAKE) $*

build_all: -build_lab1 -build_lab2 -build_lab3 -build_lab4_pt1 -build_lab4_pt2 -build_lab5


clean_all: -clean_lab1 -clean_lab2 -clean_lab3 -clean_lab4_pt1 -clean_lab4_pt2 -clean_lab5