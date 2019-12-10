// parsser222.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

 
#include<iostream> 
#include <conio.h>
#include <stdio.h>
//#include 
//#include 
void main() 
{ 
//clrscr(); 
fflush(stdin); 
char b[8][7][4],s[10],str[30],e[20]; 
int i,j,k,l,t,g,t1,t2; 
for(i=0;i<10;i++) 
s[i]='\0'; 
s[10]='\0'; 
cout<<"\t Input string\n\n"; 
cin>>str; 
/*cout<<"\t Input table\n\n"; 
for(i=0;i<6;i++) 
for(j=0;j<7;j++) 
cin>>b[i][j];*/ 
strcpy(b[0][0]," "); 
strcpy(b[0][1],"a"); 
strcpy(b[0][2],"+"); 
strcpy(b[0][3],"*"); 
strcpy(b[0][4],"("); 
strcpy(b[0][5],")"); 
strcpy(b[0][6],"$"); 
strcpy(b[1][0],"E"); 
strcpy(b[1][1],"TW"); 
strcpy(b[1][2],"q"); 
strcpy(b[1][3],"q"); 
strcpy(b[1][4],"TW"); 
strcpy(b[1][5],"q"); 
strcpy(b[1][6],"q"); 
strcpy(b[2][0],"W"); 
strcpy(b[2][1],"q"); 
strcpy(b[2][2],"+TW"); 
strcpy(b[2][3],"q"); 
strcpy(b[2][4],"q"); 
strcpy(b[2][5],"@"); 
strcpy(b[2][6],"@"); 
strcpy(b[3][0],"T"); 
strcpy(b[3][1],"FR"); 
strcpy(b[3][2],"q"); 
strcpy(b[3][3],"q"); 
strcpy(b[3][4],"FR"); 
strcpy(b[3][5],"q"); 
strcpy(b[3][6],"q"); 
strcpy(b[4][0],"R"); 
strcpy(b[4][1],"q"); 
strcpy(b[4][2],"@"); 
strcpy(b[4][3],"*FR"); 
strcpy(b[4][4],"q"); 
strcpy(b[4][5],"@"); 
strcpy(b[4][6],"@"); 
strcpy(b[5][0],"F"); 
strcpy(b[5][1],"a"); 
strcpy(b[5][2],"q"); 
strcpy(b[5][3],"q"); 
strcpy(b[5][4],"(E)"); 
strcpy(b[5][5],"q"); 
strcpy(b[5][6],"q"); 
cout<<"\n parser table \n"; 
for(i=0;i<6;i++) 
{ 
for(j=0;j<7;j++) 
coutcouts[1]='E'; 
t=1; 
l=0; 
cout<<"STACK\t INPUT\t\tACTION\n"; 
while((l{ 
for(t1=0;t1coutfor(t1=1;t1cout{ 
t--; 
l++; 
continue; 
} 
for(i=0;i<6;i++) 
if(s[t]==b[i][0][0]) 
{ 
t1=i; 
break; 
} 
for(j=0;j<7;j++) 
if(str[l]==b[0][j][0]) 
{ 
t2=j; 
break; 
} 
strcpy(e,b[t1][t2]); 
cout<<"\t\t"<"{ 
cout<<"syntax error\n press any key to exit"; 
exit(0); 
} 
strrev(e); 
for(int f=0;fs[t]=e[f]; 
t--; 
if(s[t]==str[l]) 
{ 
t--; 
l++; 
} 
else 
{ 
if(s[t]=='@') 
t--; 
} 
} 
if((s[t]=='$')&&(str[l]=='$')) 
coutcout<<"syntax error"; 
getch(); 
} 