// test.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


#include <iostream>
#include <conio.h>
#include<fstream>
#include<stdio.h>
using namespace std;
struct committee
{
	 char name[20];
	 void inputForCommittee () 
	 {
		 cout<<"Enetr the name of committee "<<endl;
		cin.getline (name , 20 ) ;
		
	 }
};
struct prerequisite
{
	char subj1[20];
	char subj2[20];
	char subj3[20];
	
};
struct club
{
	char club_name[20];
	char building_location[20];
	char phone_no[20];
	char sport1[20];
	char sport2[20];
	char sport3[20];
	char sport4[20];
	void inputForClub () 
	{
	
			cout<<"enter the club info"<<endl<<"club name :"<<endl;
			cin.ignore () ;
			cin.getline(club_name,20);
			cout<<"club building location"<<endl;
			cin.getline(building_location,20);
			cout<<"club phone number"<<endl;
			cin.getline(phone_no,20);
			cout<<"club can offer 4 sports"<<endl<<"enter the first sport "<<endl;
			cin.getline(sport1,20);
			cout<<"enter the secound sport "<<endl;
			cin.getline(sport2,20);
			cout<<"enter the third sport "<<endl;
			cin.getline(sport3,20);
			cout<<"enter the fourth sport "<<endl;
			cin.getline(sport4,20);
	}
	

};
struct supervisor
{
	int id;
	char name[20];
	char title[20];
	char officeRoom[20];
	void inputForSupervisor()
	{
		
		cout<<"Enter the id of supervisor " <<endl;
		cin >> id ;
		cout<<"enter the name of the supervisor "<<endl;
		cin.getline(name,20);
		cout<<"enter the name of the title of supervisor "<<endl;
		cin.getline(title,20);
		cout<<"enter the name of office room of the supervisor"<<endl;
		cin.getline( officeRoom, 20 ) ;
		
	}
};

struct lecturer
{
	int id;
	char name[20];
	char title[20];
	char officeRoom[20];
	supervisor s ;
	void inputForLecturer () 
	{
		cout<<"Enter the id of lecturer " <<endl;
		cin >> id ;
		cout<<"enter the name of the lecturer "<<endl;
		cin.getline(name,20);
		cout<<"enter the name of the title of lecturer "<<endl;
		cin.getline(title,20);
		cout<<"enter the name of office room of the lecturer"<<endl;
		cin.getline( officeRoom, 20 ) ;
		cout<<"enter the info of the supervisor of "<<name<<" lecturer "<<endl;
		s.inputForSupervisor();
	}
	
};

struct comitteeMember
{
	committee com;
	lecturer l1;
	lecturer l2;
	lecturer l3;
	lecturer l4;
 
};

struct course 
{
	int code ;
	char title[20];
	char grade;
	char term[10];
	int year;
	prerequisite pre;
	int numPre;
	void inputForCourse()
	{

		
			cout<<"Enter the code of  course ";
			cin>>code ;
			cout<<"Enter the name of   course ";
			cin>>grade ;
			cout<<"there are max three prerequisite course, Enter the number of prerequisite course :";
			cin>>numPre;
			if ( numPre==1)
			{
				cout<<"Enter the code of 1st prerequisite course " <<endl;
				cin>>pre.subj1 ;
			}
			else if ( numPre == 2 )
			{
				cout<<"Enter the code of 1st prerequisite course " <<endl;
				cin>>pre.subj1 ;
				cout<<"Enter the code of 2nd prerequisite course " <<endl;
				cin>>pre.subj2 ;


			}
			else if ( numPre == 3 )
			{
				cout<<"Enter the code of 1st prerequisite course " <<endl;
				cin>>pre.subj1 ;
				cout<<"Enter the code of 2nd prerequisite course " <<endl;
				cin>>pre.subj2 ;
				cout<<"Enter the code of 3rd prerequisite course " <<endl;
				cin>>pre.subj3 ;
				
			}
			
			
		}
	
};
struct program
{
	int code;
	char title[20];
	char level;
	float duration;
	
	course *c ;
	int cnum ;
	void inputForProgram ()
	{
		cout<<"Enter the code of program "<<endl;
		cin>> code ;
		cout<<"enter the title of program"<<endl;
		cin.getline(title,20);
		cout<<"enter the level of program"<<endl;
		cin>>level;
		cout<<"enter the duration of program"<<endl;
		cin>>duration;
		cout<<"enter the no. of courses in this program"<<endl;
		cin>>cnum ;
		c = new course [ cnum] ;
	}
};
struct student 
{
	char name[20];
	int id;
	char birthday[20];
	program a;
	course * elective ;
	int numelec ;
	void inputForstudent()
	{
		
			cout<<"enter the name of student"<<endl;
			cin.ignore () ;
			cin.getline(name,20);
			cout<<"enter the Id of school"<<endl;
			cin>>id ;
			cout<<"enter the birthday of student "<<endl;
			cin.getline ( birthday , 20 );
			cout<<"Enter the information related to program of " << name <<endl;
			a.inputForProgram () ;

			
		
	}
};
struct school
{
	char name[20];
	char buildingName[20];
	program p1;
	program p2;
	student * s ;
	int numstu ;
	lecturer * lec;
	int numlec ;
	void inputForSchool ()
	{
		cout<<"Enter the name of school "<<endl;
		cin.getline ( name , 20 ) ;
		cout<<"Enter the name of school "<<endl;
		cin.getline ( buildingName , 20 ) ;
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
		for ( int i = 0 ; i < numlec ;i++ )
		{
			cout<<"Enter the information related to "<< i+1 << " lecturer " << name << "school "<<endl;
			lec[ i ].inputForLecturer () ;
		}


	}
};
struct faculty
{
	char name[20];
	char deanName[20];
	char buildingName[20];
	committee cmt1 ;
	committee cmt2;
	committee cmt3;
	school s1;
	school s2;
	void inputForFaculty ()
	{
		
		
		cout<<"Enter the name of faculty :"<<endl;
		cin.ignore () ;
		cin.getline(name,20);
		cout<<"Enter the dean name of faculty :"<<endl;
		cin.getline(deanName,20);
		cout<<"Enter the building name of faculty :"<<endl;
		cin.getline(buildingName,20);
		cout<<"Enter the 1st committee information of " << name <<" faculty "<<endl;
		cmt1.inputForCommittee () ;
		cout<<"Enter the 2nd committee information of " << name <<" faculty "<<endl;
		cmt2.inputForCommittee () ;
		cout<<"Enter the 3rd committee information of " << name <<" faculty "<<endl;
		cmt3.inputForCommittee () ;
		cout<<"Enter the info for first school of"<<name <<" faculty"<<endl;
		s1.inputForSchool();
		cout<<"Enter the info for secound school of"<<name <<" faculty"<<endl;
		s2.inputForSchool();

		
		
	}
};
struct campus
{
	char name[25];
	char address[40];
	float distnace;
	char bus[10];
	club club1;
	faculty f1;
	faculty f2;
	faculty f3; 
	void inputForCampus ()
	{
		cout<<"enter the name of campus"<<endl;
		cin.ignore () ;
		cin.getline(name,25);
		cout<<"enter the address"<<endl;
		cin.getline(address,25);
		cout<<"enter the distace from city campus"<<endl;
		cin>>distnace;
		cout<<"Enter the ingormation for the club of "<< name <<" campus "<<endl;
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
		cout<<"select the campus to add information"<<endl;
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
			cout<<"you enter a wrone selection"<<endl;
		
	}
	

	
	
	
};













void main ()
{
	university abc ;
	abc.inputForUniversity() ;

}