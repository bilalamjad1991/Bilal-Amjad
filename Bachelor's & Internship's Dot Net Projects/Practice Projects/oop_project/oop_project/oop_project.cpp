// oop_project.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"




#include<iostream>
#include<windows.h>
#include<fstream>
#include<string>
#include<stdio.h>
#include<conio.h>
using namespace std;


class person
{
   public:
	char firstname[20];		//char type array of firstname 
	char lastname[20];		//char type array of lastname
    char gender[20];			
 
	
  public:
	   //Declration of the functions
	   void setperson();

	   
	 
};
////////////////////////////********implementation********//////////////////////////////////////////////////////
//////////////////////////////definition of the set function////////////////////
void person::setperson()
{ 
		   cout<<"Enter first name:";	
		   gets(firstname);				//set Firstname
		   cout<<"Enter last name:";	
		   gets(lastname);				//set Lastname
		   cout<<"Enter gender:";		
		   cin>>gender;					//set gender

}


class student:public person
{
	 
public:
	string regno;		//student registration number
	 string program;	//Degree of the student
	string course;		//Number of courses
	
public:
//////////////////////////////////////////////
	void setstudent();
	void setstudent1();
    
};

void student::setstudent()
	{ 
		person::setperson();
		cin.ignore();
		
	} 

	void student::setstudent1()
	{
		cout<<"\nEnter Registeration number : ";
		cin>>regno;
		cout<<"Enter your program : ";
		cin>>program;
	}
     
  
class dob
{	public:
	 int day;	
	 int month;
	 int year;
public:
			//Declration of the functions
	void setdate();		
	void getdate();		
	 
  };
/////////////////////////////////////*********implementation*********////////////////////////////////////////////////	
//////////////////////////////////////Definition fo the set function/////////////////////////////////////////////////
void  dob::setdate()
	{
		cout<<"Enter your date of Birth in this Format: day/month/year\t";
				 do
				 {
					
					cout<<"\n\tEnter day  :";	
					cin>>day;					//Enter Day
				 }
				  while(day<1||day>31);		//condition check day
					do
					{
					
						cout<<"\tEnter month  :";
						cin>>month;					//Enter Month
					}
					while(month<1||month>12);		//condition check month 
						do
						{
					
						cout<<"\tEnter year  :";
						cin>>year;					//Enter Year
						}	
						while(year<1900||year>1990);	//condition check year
	}
////////////////////////////////////////




  void SaveData(student p)
{    
	ofstream fout("false.txt",ios::out|ios::app);
		
	fout.write((char*)&p,sizeof(p));
	
	fout.close();
}
      
	  

  student getStudentData()
{   



   
	
	  student obj2;
	fstream fin("false.txt");
	if(!fin)
	{
		cout<<"file does not exists";
	}
	else{
	
	while(!fin.eof())
	{
	fin.read((char*)&obj2,sizeof(obj2));
	cout<<endl;
	Sleep(700);
	
	cout<<"Record of student from  file";
	cout<<"\n-------------------------------------";	
	cout<<"\nfirst name:"<<obj2.firstname<<endl;
	cout<<"lastname of person="<<obj2.lastname<<endl;
	cout<<"gender of a person="<<obj2.gender<<endl;
	cout<<"\nRegisteration number is : "<<obj2.regno;
	cout<<"\nYour program is : "<<obj2.program;
	cout<<"\nTotal Credit hours  : 142"<<endl;
	cout<<"-------------------------------------";
	}
	}
	fin.close();
	
	return obj2;
}
/////////////////////////////////dob//////////////////
  void SaveDob(dob b)
{    
	ofstream fout("dob.txt",ios::out|ios::app);
		
	fout.write((char*)&b,sizeof(b));
	
	fout.close();
}
      
	  

  dob getDob()
{   



   
	
	  dob obj2;
	fstream fin("dob.txt");
	if(!fin)
	{
		cout<<"file does not exists";
	}
	else{
	
	while(!fin.eof())
	{
	fin.read((char*)&obj2,sizeof(obj2));
	cout<<endl;
	Sleep(700);
	
	
		
	cout<<"\n-------------------------------------";
	cout<<"\nDate of Birth is : "<<obj2.day<<"/"<<obj2.month<<"/"<<obj2.year;
	cout<<"\n-------------------------------------";
	}
	}
	fin.close();
	
	return obj2;
}
//////////////////////////**********COURSE CLASS**********/////////////////////////
class courses
{

public:
	string course[30];	
	int noc;			//No. of courses

public:
////////////////////////////////////Declaration of functions////////////////////////////////////////////////////////
	void setcourse();
    
};

///////////////////////////////////////***********Implementation**********//////////////////////////////////////////
////////////////////////////////////////////Definition of set function/////////////////////////////////////////////////
void courses:: setcourse()		
{       cout<<"\nEnter 5 courses:";
	//	cout<<"Number of courses:";		
	//	cin>>noc;						//No. of courses 
		for(int i=0;i<5;i++)			//loop work to count courses
		

		{ 
			cin.ignore();				//ignore the next line while Enter
			cout<<"\nEnter course:";		
			cin>>course[i];				//Enter courses
		}

	}

/////////////////////////
 void SaveCourses(courses c)
{    
	ofstream fout("courses.txt",ios::out|ios::app);
		
	fout.write((char*)&c,sizeof(c));
	
	fout.close();
}
      
	  

  courses getCourses()
{   



   
	
	  courses obj2;
	fstream fin("courses.txt");
	if(!fin)
	{
		cout<<"file does not exists";
	}
	else{
	
	while(!fin.eof())
	{
	fin.read((char*)&obj2,sizeof(obj2));
	cout<<endl;
	Sleep(700);
	
	cout<<endl;
	cout<<"\n-------------------------------------";	 
	cout<<"\ncourses are:";
          for(int i=0;i<5;i++)	//To show courses
		{   cout<<endl;
		    
			
			cout<<"\nCourse : ";
			
			cout<<obj2.course[i];			//show courses
		}
	}
	}
	fin.close();
	
	return obj2;
}
//////////////////////////////////////contact////////////////////////
    class contact
{

public:								
	char mailadd[80];		
	string phoneno;
public:
				//Declaration of functions
	void setcont();
	
};

//////////////////////////////////////**********Implementation***********/////////////////////////////////////////
////////////////////////////////////////Definition of set function////////////////////////////////////////////
void contact:: setcont()	
	{
	    cout<<"\nEnter phone number:";		
		cin>>phoneno;
	cin.ignore();
	cout<<"Enter your address : ";		
	    gets(mailadd);			
	   
								
	}
//////////////////////////////////definition of get contact////////////////////////////////////////////////////////


void SaveInfo(contact t)
{    
	ofstream fout("contact.txt",ios::out|ios::app);
		
	fout.write((char*)&t,sizeof(t));
	
	fout.close();
}
      
	  

  contact getInfo()
{   
    
	  contact obj2;
	fstream fin("contact.txt");
	if(!fin)
	{
		cout<<"file does not exists";
	}
	else{
	
	while(!fin.eof())
	{
	fin.read((char*)&obj2,sizeof(obj2));
	cout<<endl;
	Sleep(700);
	
	
		cout<<"\n-------------------------------------";
	cout<<"\nAddress is : ";cout<<obj2.mailadd<<endl;		
	cout<<"\nPhone number is : "<<obj2.phoneno<<endl;
	
	cout<<"\n-------------------------------------";
	}
	}
	fin.close();
	
	return obj2;
}
///////////////////////////////////
void main()
{

			Sleep(1500);
			cout<<"			THE UNIVERSITY OF LAHORE			"<<endl<<endl;
            Sleep(1400);
			cout<<"\n\t\t********************************************";
			cout<<"\n\t\t*\t\tWELCOME TO\t	   *";
			cout<<"\n\t\t*\tSTUDENT REGISTRATION SYSTEM\t   *";
			cout<<"\n\t\t********************************************\n\n";
	student pp;
	pp.setstudent();
	pp.setstudent1();

SaveData(pp);

dob bb;
bb.setdate();


SaveDob(bb);


courses cc;
cc.setcourse();
SaveCourses(cc);

contact tt;
tt.setcont();
SaveInfo(tt);
Sleep(700);
system("cls");
cout<<"Retreiving record from file";
Sleep(700);
student p=getStudentData();
dob b=getDob();
courses c=getCourses();
contact t=getInfo();




}


