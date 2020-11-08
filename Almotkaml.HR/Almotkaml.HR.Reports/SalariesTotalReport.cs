namespace Almotkaml.HR.Reports
{
    public class SalariesTotalReport
    {
        public decimal BasicSalaries { get; set; }                  //ÇáãÑÊÈ ÇáÇÓÇÓí

        public decimal SocialSecurityFund { get; set; }            //  ÕäÏæÞ ÇáÖÇãä ÇáÇÌÊãÇÚí
        public decimal CompanyShareSocialSecurity { get; set; }     //ÍÕÉ ÇáÔÑßÉ ãä ÇáÖãÇä
        public decimal SafeShareSocialSecurity { get; set; }        //ÍÕÉ ÇáÎÒÇäÉ ãä ÇáÖãÇä ÇáÇÌÊãÇÚí


        public decimal SolidarityFund { get; set; }                 // ÍÕÉ ÇáãæÖÝ ãä ÇáÖãÇä
        public decimal JihadTax { get; set; }                       //ÇáÌåÇÏ
        public decimal MawadaFund { get; set; }                     //ÇáãæÏÉ
        public decimal SalariesTotal { get; set; }                  //ÇÌãÇáí ÇáãÑÊÈ
        public decimal SalariesNet { get; set; }                    //ÕÇÝí ÇáãÑÊÈ
        public decimal DeducationTotal { get; set; }                //ãÌãæÚ ÇáÎÕã
        public int    SalariesNumber { get; set; }                     //ÚÏÏ ÇáãÑÊÈÇÈ
        public decimal ContributionInSecurity { get; set; }         //ÇáãÓÇåãÉ Ýí ÇáÖãÇä
        public decimal StampTax { get; set; }                       //ÖÑíÈÉ ÇáÏãÛÉ
        public decimal Absence { get; set; }                        //ÎÕã ÇáÛíÇÈ
        public decimal Sanction { get; set; }                       // ÎÕã ÇáÌÒÇÁ
        public decimal OtherDiscount { get; set; }                  //ÎÕãíÇÊ ÇÎÑí
        public decimal IncomeTax { get; set; }                 // ضريبة الدخل
        public decimal GroupLife { get; set; }                       //الحياة الجماعي
        public decimal AdvancePayment { get; set; }               // السلف
        public decimal Clamp { get; set; }                        //åíÆÇÊ ÞÖÇÆíÉ
        public decimal Subsistence { get; set; }                       // ÇÚÇÔÉ
        public decimal Premium { get; set; }                  //ãßÇÝÆÇÊ


    }
}