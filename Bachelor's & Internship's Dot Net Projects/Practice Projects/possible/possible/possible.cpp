// possible.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <conio.h>
#include<fstream>
#include<stdio.h>
using namespace std;

char data[10];//ditance from uni
char name[25];
	char address[40];
	char club_name[30];
	char building_location[20];
	char phone_no[20];
	char sport1[20];
	char sport2[20];
	char sport3[20];
	char sport4[20];
	char fac_name[20];
	char deanName[20];
	char buildingName[20];
	char com_name[20];

	int pre;
	int code1;
	int code ;
	int code2;
	char title[20];
	char grade;
	char term[10];
	int year;
	int precode1;
	int precode2;
	int precode3;
	int numPre;
	
	char stu_name[20];
	int id;
	char birthday[20];
    int numelec ;
	int csubj;

	char sch_name[20];
	char sch_buildingName[20];


struct club
{
	/*char club_name[20];
	char building_location[20];
	char phone_no[20];
	char sport1[20];
	char sport2[20];
	char sport3[20];
	char sport4[20];*/
	void inputForClub ()
	{
		ofstream outfile;
		outfile.open("club.txt");
			cout<<"enter the club info"<<endl<<"club name :"<<endl;
			cin.ignore () ;
			cin.getline(club_name,30);
			outfile<<club_name<<endl;
			cout<<"club building location"<<endl;
			cin.getline(building_location,20);
			outfile<<building_location<<endl;
			cout<<"club phone number"<<endl;
			cin.getline(phone_no,20);
			outfile<<phone_no<<endl;
			cout<<"club can offer 4 sports"<<endl<<"enter the first sport "<<endl;
			cin.getline(sport1,20);
			outfile<<sport1<<endl;
			cout<<"enter the second sport "<<endl;
			cin.getline(sport2,20);
			outfile<<sport2<<endl;
			cout<<"enter the third sport "<<endl;
			cin.getline(sport3,20);
			outfile<<sport3<<endl;
			cout<<"enter the fourth sport "<<endl;
			cin.getline(sport4,20);
			outfile<<sport4<<endl;
			outfile.close();
	}


};

struct lecturer
{
	int id;
	char name[20];
	char title[20];
	char officeRoom[20];
	
	void inForLecName()
	{
		
		cout<<"NAME: ";
		cin.getline(name,20);
		cout<<"id : ";
		cin >> id ;
		
	}
	void inputForLecturer ()
	{
		cout<<"Enter the id of lecturer " <<endl;
		cin >> id ;
		cout<<"enter the name of the title of lecturer "<<endl;
		cin.getline(title,20);
		cout<<"enter the name of office room of the lecturer"<<endl;
		cin.getline( officeRoom, 20 ) ;
		cout<<"enter the info of the supervisor of "<<name<<" lecturer "<<endl;
		
	}

};
		
		



struct committee
{
	 /*char com_name[20];*/
	 lecturer lec1 ;
	 lecturer lec2 ;
	 lecturer lec3 ;
	 void inputForCommittee ()
	 {
		 ofstream outfile;
		 outfile.open("committee.txt");
		 cout<<"Enter the name of committee "<<endl;
		 cin.getline (com_name , 20 ) ;
		 outfile<<com_name<<endl;
		 cout<<"enter the names of comiittee members"<<endl;
		 lec1.inForLecName();
		 cin.ignore();
		 lec2.inForLecName();
		 cin.ignore();
		 lec3.inForLecName();
		outfile.close(); 
	 }
};


struct course
{/*
	int pre;
	int code1;
	int code ;
	int code2;
	char title[20];
	char grade;
	char term[10];
	int year;
	int precode1;
	int precode2;
	int precode3;
	int numPre;*/
	
	void studentCorse()
	
	{
		ofstream outfile;
        outfile.open("course.txt"); 

		cout<<"enter the corse code you have studied "<<endl;
		cin>>code1;
		outfile<<code1<<endl;
		cout<<"enter the title of the course "<<endl;
		cin.getline(title,20);
		outfile<<title<<endl;
		cout<<"Enter the grade of course (a,b,c,d,f)"<<endl;
		cin>>grade;
		outfile<<grade<<endl;
				
			if (grade=='A'||'a'||'b'||'B'||'c'||'C'||'d'||'D')
			{
			
				cout<< "u have passed in this course code :"<<code1<<"you awarded grade""<<grade<<"""<<endl;
				cout<<"enter new course code against course code :"<<code1;
				cin>>code2;
				outfile<<code2<<endl;
				cout<<"you have selected the course :"<<code2<<endl;
			}
			else 
			{
				cout<<"you have to retake this corse"<<endl;
				code1=code2;
				cout<<"your corse code="<<code1<<" selected again"<<endl;
				
			}
			outfile.close();	


	}
	void inputPre()
	{
		 ofstream outfile;
		     outfile.open("inputpre.txt"); 

			
			cout<<"Enter the code of  course ";
			cin>>code ;
			outfile<<code<<endl;
			cout<<"enter the no. of prerequsite of this course(o,1,2,3)"<<endl;
			cin>>numPre;
			outfile<<numPre<<endl;
			if (numPre == 1||2||3)
			{
				
				if ( numPre==1)
				{
					cout<<"Enter the code prerequisite course " <<endl;
					cin>>precode1 ;
					outfile<<precode1<<endl;
				}
				else if ( numPre == 2 )
				{
					cout<<"Enter the code of prerequisite course " <<endl;
					cin>>precode1 ;
					outfile<<precode1<<endl;
					cout<<"Enter the code of 2nd prerequisite course " <<endl;
					cin>>precode2 ;
                   outfile<<precode2<<endl;

				}
				else if ( numPre == 3 )
				{
					cout<<"Enter the code of prerequisite course " <<endl;
					cin>>precode1 ;
					outfile<<precode1<<endl;
					cout<<"Enter the code of 2nd prerequisite course " <<endl;
					cin>>precode2 ;
					outfile<<precode2<<endl;
					cout<<"Enter the code of 3rd prerequisite course " <<endl;
					cin>>precode3 ;
					outfile<<precode3<<endl;
				}

			}
outfile.close();
		}

};
struct program
{
	int code;
	char title[20];
	char level[20];
	char duration[20];
	course cor;
	course *c ;
	int cnum ;
	void inputForProgramStud()
	{
		cout<<"Enter the code of program "<<endl;
		cin>> code ;
		cin.ignore();
		cout<<"enter the title of program"<<endl;
		cin.getline(title,20);
	}
	void inputForProgram ()
	{
		cout<<"Enter the code of program "<<endl;
		cin>> code ;
		cout<<"enter the title of program"<<endl;
		cin.getline(title,20);
        cin.ignore();
		cout<<"enter the level of program"<<endl;
		cin.getline(level,20);
		cin.ignore();
		cout<<"enter the duration of program"<<endl;
		cin.getline(duration,20);
		cout<<"enter the no. of courses in this program"<<endl;
		cin>>cnum ;
		c = new course [ cnum] ;
		for (int i =0 ; i < cnum ; i++)
		{
			cor.inputPre();
		}
	}
};
		
		
	

struct student
{
	/*char name[20];
	int id;
	char birthday[20];*/
	program a;
	course grading ;
	/*int numelec ;
	int csubj;*/
	void inputForstudent()
	{
		ofstream outfile;
		outfile.open("student.txt");

			cout<<"enter the name of student"<<endl;
			cin.ignore () ;
			cin.getline(stu_name,20);
			outfile<<stu_name<<endl;
			cout<<"enter the Id of student"<<endl;
			cin>>id ;
			outfile<<id<<endl;

			cout<<"enter the birthday of student "<<endl;
			cin.getline ( birthday , 20 );
		    cin>>birthday;
			outfile<<birthday<<endl;
			cout<<"Enter the information related to program of student" << name <<endl;
			cin.ignore();
			a.inputForProgramStud() ;
			cout<<"it is student grading"<<endl;
			cout<<"enter the number of sunjects student have studied in semester"<<endl;
			cin>>csubj;
			outfile<<csubj<<endl;
			for ( int i = 0 ; i < csubj;i++)
			{
				grading.studentCorse();

			}

outfile.close();
	}
};
struct school
{
	/*char name[20];
	char buildingName[20];*/
	program p1;
	program p2;
	student * s ;
	int numstu ;
	lecturer * lec;
	int numlec ;
	void inputForSchool ()
	{
		ofstream outfile;
		outfile.open("school.txt");
		cout<<"Enter the name of school "<<endl;
		cin.getline ( sch_name , 20 ) ;
		outfile<<sch_name<<endl;
		cout<<"Enter the building name of school "<<endl;
		cin.getline ( sch_buildingName , 20 ) ;
		outfile<<sch_buildingName<<endl;
		cout<<"Enter the information related to 1st program in " << name <<" school " <<endl;
		p1.inputForProgram () ;
		cout<<"Enter the information related to 2nd program in " << name <<" school " <<endl;
		p2.inputForProgram ();
		cout<<"Enter the number of students in " << name << " school "<<endl;
		cin >> numstu ;
		s = new student [ numstu ] ;
		for ( int i = 0 ; i < numstu ;i++ )
		{
			cout<<"Enter the information related to "<< i+1 << " student of  " << name << "school " <<endl;
			s[ i ].inputForstudent () ;
		}

		cout<<"Enter the number of Lecturers in " << name << " school "<<endl;
		cin >> numlec ;
		lec = new lecturer [ numlec ] ;
		for ( int j = 0 ; j < numlec ;j++ )
		{
			cout<<"Enter the information related to "<< j+1 << " lecturer " << name << "school "<<endl;
			cin.ignore();
			lec[ j ].inputForLecturer ();
		}

outfile.close();
	}
};
struct faculty
{
	/*char name[20];
	char deanName[20];
	char buildingName[20];*/
	committee cmt1 ;
	
	committee cmt2;

	committee cmt3;


	school s1;
	school s2;
	void inputForFaculty ()
	{
		ofstream outfile;
		outfile.open("faculty.txt");

		cout<<"Enter the fac name of faculty :"<<endl;
		cin.getline(fac_name,20);
		outfile<<fac_name<<endl;
		
		cout<<"Enter the dean name of faculty :"<<endl;
		cin.getline(deanName,20);
		outfile<<deanName<<endl;
		cout<<"Enter the building name of faculty :"<<endl;
		cin.getline(buildingName,20);
		outfile<<buildingName<<endl;
		cout<<"Enter the 1st committee information of " << name <<" faculty "<<endl;
		cmt1.inputForCommittee () ;
		cin.ignore();
		cout<<"Enter the 2nd committee information of " << name <<" faculty "<<endl;
		cin.ignore();
		cmt2.inputForCommittee () ;
		
		cout<<"Enter the 3rd committee information of " << name <<" faculty "<<endl;
		cin.ignore();
		cmt3.inputForCommittee () ;
		
		cout<<"Enter the info for first school of"<<name <<" faculty"<<endl;
		cin.ignore();
		s1.inputForSchool();
		cout<<"Enter the info for second school of"<<name <<" faculty"<<endl;
		cin.ignore();
		s2.inputForSchool();

outfile.close();

	}
};
struct campus
{
	//char name[25];
	//char address[40];
	//float distance;
	char bus[10];
	club club1;
	faculty f1;
	faculty f2;
	faculty f3;
	void inputForCampus ()
	{
		ofstream outfile;
        outfile.open("campus.txt"); 
		cout<<"enter the name of campus"<<endl;
		cin.ignore () ;
		cin.getline(name,25);
		outfile<<name<<endl;
		cout<<"enter the address"<<endl;
		cin.getline(address,25);
		outfile<<address<<endl;
		
		
		cout<<"enter the distance from city campus"<<endl; 
            cin >> data;
              cin.ignore();
			  outfile<<data<<endl;
			  outfile.close();
		cout<<"Enter the information for the club of "<< name <<" campus "<<endl;
		club1.inputForClub () ;
		cout<<"Enter the information of 1st faculty  for " << name << " campus "<<endl;
		f1.inputForFaculty () ;
		cout<<"Enter the information of 2nd faculty  for " << name << " campus "<<endl;
		f2.inputForFaculty () ;
		cout<<"Enter the information of 3rd faculty  for " << name << " campus "<<endl;
		f3.inputForFaculty () ;
		
	}
};
struct university
{
	campus c1;
	campus c2;
	campus c3;

	void inputForUniversity ()
	{
		int cond;
		cout<<"select the campus to add information(1,2,3)"<<endl;
		cin>>cond;
		if ( cond == 1)
		{
			cout<<"Enter the data for campus 1 " <<endl;
			c1.inputForCampus () ;
		}
		else if (cond == 2)
		{
			cout<<"Enter the data for campus 2 " <<endl;
			c2.inputForCampus () ;
		}
		else if (cond == 3)
		{
			cout<<"Enter the data for campus 3 " <<endl;
			c3.inputForCampus () ;
		}
		else
			cout<<"you enter a wrong selection"<<endl;

	}





};













void main ()
{
	university abc ;
	abc.inputForUniversity() ;
	ifstream infile; 
   infile.open("campus.txt");
	infile>>name;
	cout<<name<<endl;
	infile>>address;
	cout<<address<<endl;

	infile>> data;
	 cout<<  data<<endl;
	 infile.close();
	
	 infile.open("club.txt");
	infile>>club_name;
	 cout<< club_name<<endl; 

	 infile>> building_location;

	 cout<<building_location<<endl;  

	 infile>> phone_no;
	 cout<< phone_no<<endl; 

	 infile>> sport1;
	 cout<<sport1<<endl;  
	 infile>> sport2;
	 cout<< sport2<<endl;
	 infile>>sport3;
	 cout<<sport3<<endl;
	 infile>>sport4;
	 cout<<sport4<<endl;
	  infile.close();
	infile.open("faculty.txt");
	 infile>>fac_name;
	 cout<<fac_name<<endl;
	 infile>>deanName;
	 cout<<deanName<<endl;
	 infile>>buildingName;
	 cout<<buildingName<<endl;
	  infile.close();
	infile.open("committee.txt");
	 infile>>com_name;
	 cout<<com_name<<endl;
	 infile.close();

	 infile.open("course.txt");
	 
	infile>>code1;
	cout<<code1<<endl;
	infile>>title;
	cout<<title<<endl;

	infile>>grade;
	 cout<<grade<<endl;

	 infile>>code2;
	cout<<code2<<endl;
	 infile.close();

	 infile.open("inputpre.txt");
	infile>>code;
	cout<<code<<endl;
	infile>>numPre;
	 cout<<numPre<<endl;
	 infile>>precode1;
	 cout<<precode1<<endl;
	 infile>>precode1;
	 cout<<precode1<<endl;
	 infile>>precode2;
	 cout<<precode2<<endl;
	 infile>>precode1;
	 cout<<precode1<<endl;
	 infile>>precode2;
	 cout<<precode2<<endl;
	  infile>>precode3;
	 cout<<precode3<<endl;
	 infile.close();
     infile.open("student.txt");
	 infile>>stu_name;
	 cout<<stu_name<<endl;
	 infile>>id;
	 cout<<id<<endl;
	 infile>>birthday;
	 cout<<birthday<<endl;
	 infile>>csubj;
	 cout<<csubj<<endl;
	 infile.close();
	 infile.open("school.txt");
	 infile>>sch_name;
	 cout<<sch_name<<endl;
	 infile>>sch_buildingName;
	 cout<<sch_buildingName<<endl;
	 infile.close();



	char e;
	cout<<"enter e to exit:";
	cin>>e;
}

