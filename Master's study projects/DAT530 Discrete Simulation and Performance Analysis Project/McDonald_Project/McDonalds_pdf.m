function [png] = McDonalds_pdf()
png.PN_name = 'McDonalds_pdf';
png.set_of_Ps = {'pCustEntry','pO&PQueue','pOrderWaiting','pOrderGettingReady','pOrderIsReady','pEating','pFinish','pTakeAway',...
    'pAssgnTyp','pCustDispatch','pDTQueue','pOC&PQueue','pDTFinish','pRCustLeave','pDTCustLeave'};

png.set_of_Ts = {'tCustEntry','tO&PQueue1','tOrderPreparation','tOrderIsReady','tOrderCollection','tFinishEating','tTakeAway',...
    'tAssgnTyp','tOrderQueue','tDTQueue','tOrder','tOC&PQueue','tOC&P','tRCustLeave','tDTCustLeave'};

png.set_of_As = {   'pCustEntry','tCustEntry',1, ...
                    'tCustEntry','pCustEntry',1,...
                    'tCustEntry','pAssgnTyp',1,...
                    'pAssgnTyp','tAssgnTyp',1,...
                    'tAssgnTyp','pCustDispatch',1,...
                    'pCustDispatch','tOrderQueue',1,...
                    'tOrderQueue','pO&PQueue',1,...
                    'pO&PQueue','tO&PQueue1',1,...
                    'tO&PQueue1','pOrderWaiting',1,...
                    'pO&PQueue','tRCustLeave',1,...   
                    'tRCustLeave','pRCustLeave',1,...   
                   'pCustDispatch','tDTQueue',1,...      
                    'tDTQueue','pDTQueue',1,...
                    'pDTQueue','tOrder',1,...
                    'tOrder','pOrderWaiting',1,...
                    'pDTQueue','tDTCustLeave',1,...      
                    'tDTCustLeave','pDTCustLeave',1,...      
                     'pOrderWaiting','tOrderPreparation',1,...
                     'tOrderPreparation','pOrderGettingReady',1,...
                     'pOrderGettingReady','tOrderIsReady',1,...
                     'tOrderIsReady','pOrderIsReady',1,...
                     'pOrderIsReady','tOC&PQueue',1,...     
                     'tOC&PQueue','pOC&PQueue',1,...
                     'pOC&PQueue','tOC&P',1,...
                     'tOC&P','pDTFinish',1,...
                     'pOrderIsReady','tOrderCollection',1,...
                     'tOrderCollection','pEating',1,...
                     'pEating','tTakeAway',1,...   
                   'tTakeAway','pTakeAway',1,...   
                     'pEating','tFinishEating',1,...
                     'tFinishEating','pFinish',1,...
                     };