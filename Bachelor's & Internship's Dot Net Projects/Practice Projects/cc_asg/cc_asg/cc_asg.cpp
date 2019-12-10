// cc_asg.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <conio.h>
#include<stdio.h>
using namespace std;
int main()
{
	char dfa[3][3] ={"01",
					 "12",
					 "22"};/// [x][y] lang on a,b excpts only strings with one b in it.
	char start_state = '0';
	char accept_state = '1';
	char input[10] = "baaraaba";
	int i=0;// lexem current pointer
	char temp = '0',temp2 = '0';
	int start_point=0;// lexem begin pointer
	while(input[i] != '\0')
	{
		int token_length = 0;
		int x=0,y=0;// start state
		char current_state = start_state  - 48;
		int ti= 0;
		char tempStr[10] = "\0";
		while (true)
		{
			temp= input[i];
			if (temp == 'a')
			{
				y = 0;
				x = dfa[x][y]- 48;
				tempStr[ti]= temp;
				ti++;
			}
			else if (temp == 'b')
			{
				y = 1;
				x = dfa[x][y] - 48;
				tempStr[ti]= temp;
				ti++;
			}
			else// if anything other then a, b is read..
			{
				break;
			}
		
			i++;
		
		}
		if (x == 1 )// this is accepting state
		{
			cout<<"ACCEPTED "<<tempStr<<"  LENGTH "<<ti<<endl;
			start_point=i;
		}
		else // not accepting state
		{
			char ttstr[10];
			int t,tt;
			for ( tt = start_point, t=0; tt <= i; tt++, t++)
			{
				ttstr[t]=input[tt];
			}
			ttstr[t]='\0';
			cout<<"NOT ACCEPTED "<<ttstr<<"  LENGTH "<<t<<endl;
			i++;
			start_point=i;
		}
	}
	system("pause");
	return 0;
}


