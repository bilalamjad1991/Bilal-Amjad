clear all; clc;

global global_info
%16 hours working shift of the restaurant is represented by 576000 seconds
global_info.STOP_AT = 57600;  
%represents 5 types of customers in the form of colors
%'RCustLeave' includes DineInn & TakeAway Leaving customers while
%'DTCustLeave' includes DriveThru Leaving customers
global_info.CustomerType = {'DineInn', 'TakeAway', 'DriveThru','RCustLeave','DTCustLeave'}; 
%It is the probability of 5 types of customers
global_info.CustomerProbability = [0.2 0.2 0.2 0.2 0.2 ]; 
% time and counter values are used for the token generation
time = 0;
counter = 0;
global_info.TokenGeneration_Times = zeros(1, 20000); %An array having token generation times
% For the generation of customers untill the specified time
while lt(time , 57600)
    counter = counter + 1;
    time = time + normrnd(410, 200);
    global_info.TokenGeneration_Times(counter) = time;
end

pns = pnstruct('McDonalds_pdf');
dyn.m0 = {'pCustEntry', 1};
dyn.ft = {'tCustEntry', 5,...
         'tO&PQueue1',10,...
         'tOrderPreparation',10,...
         'tOrderIsReady',10,...
         'tOrderCollection',10,...
         'tFinishEating',10,...
         'tTakeAway',10,...
         'tAssgnTyp',10,...   
         'tOrderQueue',10,...
         'tDTQueue',10,...
         'tOrder',10,...
        'tOC&PQueue',10,...
        'tOC&P',10,...
        'tRCustLeave',10,...
        'tDTCustLeave',10};
      
pni = initialdynamics(pns, dyn);
sim = gpensim(pni);
  prnss(sim);
% cotree(pni,1,1);
prnfinalcolors(sim);
% prnschedule(sim);
%plotp(sim,{'pFinish','pTakeAway','pDTFinish'})
%plotp(sim, {'pRCustLeave','pDTCustLeave','pOrderWaiting'});
disp(['Total number of customers: ', num2str(counter)]);