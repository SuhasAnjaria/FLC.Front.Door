﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using flc.FrontDoor.Data;
using flc.FrontDoor.ViewModels;
using flc.FrontDoor.FacadeService;

namespace flc.FrontDoor.Models
{
    
    class RatesMatrixModel
    {
        string A = "-,1m,1y,0.2,2y,1.3|-,2m,1y,0.2,2y,1.3|-,3m,1y,0.2,2y,1.3|-,4m,1y,0.2,2y,1.3";
        public string[] B = new string[]
             { 
            "|-,1m,1y,0.590260905959435,18m,0.255812086893749,2y,0.968009889311047,3y,0.170263786442071,4y,0.418368516373894,5y,0.148230220133066,6y,0.382669834485875,7y,0.72485341110629,8y,0.314245623363502,9y,0.967590768808966,10y,0.710708182820818,12y,0.693636370570779,15y,0.238261094197396,20y,0.301369765937273,25y,0.00488206479865183,30y,0.805764702100845"
            , 
            "|-,3m,1y,0.292748967046786,18m,0.655866816244395,2y,0.557863946401575,3y,0.0486306246174607,4y,0.0544307714958647,5y,0.334957793647521,6y,0.80845303460603,7y,0.163093720528212,8y,0.0700952589514399,9y,0.0461669110829592,10y,0.140995401589623,12y,0.993825345359326,15y,0.403993302324896,20y,0.194269997384331,25y,0.73987168345518,30y,0.654636499440302"
            , 
            "|-,6m,1y,0.819116537943438,18m,0.276099669152348,2y,0.888692261697761,3y,0.41727766086294,4y,0.105196413369955,5y,0.173474463701332,6y,0.376368191926794,7y,0.106398703133924,8y,0.759348732785103,9y,0.961161275562026,10y,0.312677785278448,12y,0.534404837585987,15y,0.70252651936152,20y,0.588388910992973,25y,0.710425444178974,30y,0.312707107527672"
            , 
            "|-,9m,1y,0.966131587055573,18m,0.816824864235885,2y,0.221214385166239,3y,0.649544144335201,4y,0.222162965804963,5y,0.791182284978963,6y,0.0792811400585426,7y,0.0263310374316681,8y,0.465693932371404,9y,0.874399615535007,10y,0.06273959679526,12y,0.661249554895428,15y,0.391341688176939,20y,0.283693841830306,25y,0.197190908803119,30y,0.603426179213578"
            , 
            "|-,1y,1y,0.54028439493845,18m,0.234355549717763,2y,0.576993349692604,3y,0.356294955150167,4y,0.370374790188692,5y,0.893329968395623,6y,0.791710048877734,7y,0.535369272516815,8y,0.95006345499095,9y,0.265756197676036,10y,0.730417335894278,12y,0.658876612848271,15y,0.988618819175335,20y,0.610015363815986,25y,0.334990027225556,30y,0.560990195211046"
            , 
            "|-,18m,1y,0.463782460015195,18m,0.267426878808812,2y,0.707414246965944,3y,0.41598000833969,4y,0.0183955818785284,5y,0.0714365386272573,6y,0.893066271484709,7y,0.558976002762481,8y,0.968697883630982,9y,0.903568721802288,10y,0.763083410598423,12y,0.698027035197745,15y,0.554204955422774,20y,0.967864891221547,25y,0.207451567436566,30y,0.435118733053892"
            , 
            "|-,2y,1y,0.846452898697448,18m,0.435974267526846,2y,0.727188349786562,3y,0.0515559489374245,4y,0.583119039414856,5y,0.148458394043182,6y,0.807806019305984,7y,0.377512176755428,8y,0.546393464454338,9y,0.811526292688085,10y,0.435008319553207,12y,0.426212664721958,15y,0.105135672805604,20y,0.422888627688055,25y,0.97239887530298,30y,0.594502442254365"
            , 
            "|-,3y,1y,0.199961147531167,18m,0.822885212855533,2y,0.879870897837545,3y,0.552005970684617,4y,0.684605053539624,5y,0.777039078902144,6y,0.0901285316296537,7y,0.669684638699705,8y,0.396450219142524,9y,0.907803584218383,10y,0.286413765511495,12y,0.479078881325524,15y,0.499264647671846,20y,0.839233080862265,25y,0.519149521304887,30y,0.679552578362776"
            , 
            "|-,4y,1y,0.907431193127617,18m,0.814658245287306,2y,0.712869358138858,3y,0.0200359302489147,4y,0.455262663713318,5y,0.50465461276971,6y,0.530587685575085,7y,0.0276457929737618,8y,0.371643041178094,9y,0.556392558011139,10y,0.755978847489653,12y,0.114253022419416,15y,0.683720540076761,20y,0.647611195730531,25y,0.391355090043584,30y,0.157224763568999"
            , 
            "|-,5y,1y,0.227419833172086,18m,0.586518022491827,2y,0.0537504325792056,3y,0.647925854557383,4y,0.634148845262991,5y,0.661520026172395,6y,0.35995316681272,7y,0.615023786020188,8y,0.919432911440717,9y,0.715091940585812,10y,0.977663318288104,12y,0.104059792346089,15y,0.855071511535811,20y,0.4843028893162,25y,0.409105129740367,30y,0.586787420593858"
            , 
            "|-,6y,1y,0.810001139014312,18m,0.969584184780912,2y,0.237118802209859,3y,0.525220907705204,4y,0.149019321887442,5y,0.65041701933877,6y,0.0732844141767962,7y,0.0774523317588224,8y,0.175769687803217,9y,0.13527739259965,10y,0.13607062698789,12y,0.567074808897832,15y,0.392712610504526,20y,0.423048160508135,25y,0.850926551828829,30y,0.984560560451468"
            , 
            "|-,7y,1y,0.564534230288606,18m,0.207702619036141,2y,0.639943445134527,3y,0.363641824871538,4y,0.58545770287545,5y,0.797055278857962,6y,0.217809182897637,7y,0.228975379073842,8y,0.300287132526465,9y,0.233941228229305,10y,0.915939074047968,12y,0.712088379068583,15y,0.0156057314703203,20y,0.177382534102676,25y,0.206587777432009,30y,0.587723764412611"
            , 
            "|-,8y,1y,0.660373612658724,18m,0.925750358508361,2y,0.845844513664703,3y,0.740189679381421,4y,0.562640130849141,5y,0.487720496993443,6y,0.831455365696126,7y,0.228897782786833,8y,0.685832096352716,9y,0.102051656316855,10y,0.727136130271893,12y,0.955770282537213,15y,0.292552481580231,20y,0.355774409693969,25y,0.17424793544594,30y,0.0975364647479102"
            , 
            "|-,9y,1y,0.888047579593608,18m,0.0999139543461078,2y,0.356058874985562,3y,0.624049776005511,4y,0.0415399781316701,5y,0.375434836883534,6y,0.765202663831382,7y,0.816615775584844,8y,0.644355386755489,9y,0.0147783970280675,10y,0.447076243035471,12y,0.197516331370627,15y,0.258028770058733,20y,0.612813157816632,25y,0.680921681325267,30y,0.142586893712743"
            , 
            "|-,10y,1y,0.541977853459425,18m,0.210241845676861,2y,0.51771459054816,3y,0.602831457500726,4y,0.548362999981267,5y,0.922930976078236,6y,0.362778834055044,7y,0.304565016176881,8y,0.313001121310104,9y,0.349373844122616,10y,0.435402985490906,12y,0.621524200540533,15y,0.494899600400847,20y,0.440005978234558,25y,0.571219197524742,30y,0.858798704690778"
            , 
            "|-,12y,1y,0.477332710124838,18m,0.177153567995831,2y,0.0409877527977903,3y,0.314084024531537,4y,0.228775053995699,5y,0.871118299804372,6y,0.329419339684767,7y,0.377841011349042,8y,0.478142946933857,9y,0.918754468116157,10y,0.523076218261351,12y,0.92137587275448,15y,0.78453328224864,20y,0.242126314279183,25y,0.29650472972726,30y,0.481157576199237"
            , 
            "|-,15y,1y,0.311829535265911,18m,0.339664271135067,2y,0.443273795924908,3y,0.937715975079758,4y,0.248974155884207,5y,0.747814440577811,6y,0.98892408914521,7y,0.95316640372181,8y,0.933049193988682,9y,0.0607361352810225,10y,0.788161279439723,12y,0.870013486000821,15y,0.214280796564241,20y,0.800920479545365,25y,0.814332940139525,30y,0.135464221016198"
            , 
            "|-,20y,1y,0.971747725288779,18m,0.13310169978764,2y,0.230089557788454,3y,0.386927467785585,4y,0.986087559090517,5y,0.0247012852369436,6y,0.376800816201677,7y,0.498210734302083,8y,0.0350781358838246,9y,0.801397157228461,10y,0.0273522999448087,12y,0.820035551686645,15y,0.765265858227686,20y,0.862917832918373,25y,0.472130405397074,30y,0.0387850149492703"
            , 
            "|-,25y,1y,0.363794575400882,18m,0.335918373591681,2y,0.197416279905775,3y,0.550471931668696,4y,0.917089145833334,5y,0.932281888569371,6y,0.244348672257352,7y,0.783179920919635,8y,0.59304974081801,9y,0.256193037659314,10y,0.377283571880354,12y,0.893861485503274,15y,0.558674232418923,20y,0.502173243526477,25y,0.010795463795527,30y,0.0479322235057174"
            , 
            "|-,30y,1y,0.0644859624457759,18m,0.667652376343649,2y,0.0635674966559178,3y,0.0247837587496574,4y,0.623604149988007,5y,0.100963615603458,6y,0.785761293668174,7y,0.0792036492300362,8y,0.585815883537597,9y,0.0218369736956365,10y,0.687852575264939,12y,0.989409825828873,15y,0.493559104899895,20y,0.844026926809261,25y,0.349713808337143,30y,0.474586379162918" 
           
            };
        string C;
        private RatesViewModel _ratesViewModel;
        static RatesMatrixModel()
        {
             
            
        }

        public  void RatesViewModel_GridDataAdded(RatesViewModel sender, flc.FrontDoor.ViewModels.RatesViewModel.GridEventArgs e)
        {
            using (FacadeServiceClient session = new FacadeServiceClient())
            {
                var A = session.GetRatesMatrix("USD", "Swap", "Libor3m", "Mid", new DateTime(2015, 7, 9));

                C = String.Join("", A.DataRowList);
                _ratesViewModel = sender;
                _ratesViewModel.MatrixArgs = DynamoGenerator.GenerateDataGridObjects(C);
            }
        }
    }


    

}