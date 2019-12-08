function [fire, transition] = COMMON_PRE(transition)
global global_info;

%this transition is for creating a new token in the form of a customer
if (strcmpi(transition.name, 'tCustEntry'))
    % Don't let the transition fire if the array is empty
    if isempty(global_info.TokenGeneration_Times)
        fire = 0;
        return;
    end;
    cTime = current_time(); %to get the current time
    genrationTime = global_info.TokenGeneration_Times(1);
    % Don't let the transition fire if the remaining generation times in the array are equal to 0
    if eq(genrationTime , 0)
        fire = 0;
        global_info.TokenGeneration_Times = [];
        return;
    end;
    % Don't let the transition fire if current time is lower than the generation time
    if lt(cTime , genrationTime)
        fire = 0;
        return;
    end;
    % It is time to fire
    if ge(length(global_info.TokenGeneration_Times), 2)
        global_info.TokenGeneration_Times = global_info.TokenGeneration_Times(2:end);
    else
        global_info.TokenGeneration_Times = [];
    end;
    fire = 1;
    
    %this transition is for assigning a random color to the customer/token
elseif(strcmpi(transition.name, 'tAssgnTyp'))
         
 %Function for getting cumulative distribution of customers
    cumDist = [0 cumsum(global_info.CustomerProbability)];
    %for the random selection of customers in relation to the given...
    %customer probability
    select = rand();
    greater = find(cumDist >= select==1,1); 
    transition.new_color = global_info.CustomerType{greater-1};
    transition.override = true;
    fire=1;
    
    %this transition is for selecting a token if it's color is one of these i.e., 'DineInn', 'TakeAway','RCustLeave'
elseif(strcmpi(transition.name, 'tOrderQueue'))
    tokID1 = tokenAnyColor('pCustDispatch',1, {'DineInn', 'TakeAway','RCustLeave'});   
    transition.selected_tokens = tokID1; 
    fire = tokID1;
  %this transition is for selecting a token if it's color is one of these i.e., 'DriveThru','DTCustLeave'  
elseif(strcmpi(transition.name, 'tDTQueue'))
    tokID1 = tokenAnyColor('pCustDispatch',1, {'DriveThru','DTCustLeave'});       
    transition.selected_tokens = tokID1; 
    fire = tokID1;
   %this transition is for selecting a token if it's color is exactly equal to 'DriveThru' 
elseif(strcmpi(transition.name, 'tOrder'))
    tokID1 = tokenEXColor('pDTQueue',1, {'DriveThru'});                 
    transition.selected_tokens = tokID1; 
    fire = tokID1;
    %this transition is for selecting a token if it's color is exactly...
    %equal to 'DTCustLeave'
    elseif(strcmpi(transition.name, 'tDTCustLeave'))
    tokID1 = tokenEXColor('pDTQueue',1, {'DTCustLeave'});                 
    transition.selected_tokens = tokID1; 
    fire = tokID1;
    %this transition is for selecting a token if it's color is one of these
    %i.e., 'DineInn', 'TakeAway'
elseif(strcmpi(transition.name, 'tO&PQueue1'))
   tokID1 = tokenAnyColor('pO&PQueue',1, {'DineInn', 'TakeAway'});   
    transition.selected_tokens = tokID1; 
    fire = tokID1;
    %this transition is for selecting a token if it's color is exactly...
    %equal to 'RCustLeave'
    elseif(strcmpi(transition.name, 'tRCustLeave'))
   tokID1 = tokenEXColor('pO&PQueue',1, {'RCustLeave'});   
    transition.selected_tokens = tokID1; 
    fire = tokID1;
    
elseif(strcmpi(transition.name, 'tOrderPreparation'))
    fire=1;
    
elseif(strcmpi(transition.name, 'tOrderIsReady'))
    fire=1;
    %this transition excludes tokens with color 'DriveThru' and selects
    %tokens only with colors 'DineInn', 'TakeAway'
elseif(strcmpi(transition.name, 'tOrderCollection'))
     tokID1 = tokenWOEXColor('pOrderIsReady',1, {'DriveThru'});
    transition.selected_tokens = tokID1; 
    fire = tokID1;
    %this transition selects token with exact color i.e., 'DriveThru' 
elseif(strcmpi(transition.name, 'tOC&PQueue'))
     tokID1 = tokenEXColor('pOrderIsReady',1, {'DriveThru'});
    transition.selected_tokens = tokID1; 
    fire = tokID1;
    
elseif(strcmpi(transition.name, 'tOC&P'))
    fire=1;
   %this transition selects token with exact color i.e., 'DineInn'
elseif(strcmpi(transition.name, 'tFinishEating'))
   tokID1 = tokenEXColor('pEating',1, {'DineInn'});
   transition.selected_tokens = tokID1; 
    fire = tokID1;

    %this transition selects token with exact color i.e., 'TakeAway'
elseif(strcmpi(transition.name, 'tTakeAway'))
     tokID1 = tokenEXColor('pEating',1, {'TakeAway'});
    transition.selected_tokens = tokID1; 
    fire = tokID1;
end;    