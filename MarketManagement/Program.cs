using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            MethodClass methods = new MethodClass();

            bool myBool = false;
            bool sechim = false;

            while (!myBool)
            {
                Console.WriteLine("1 - Mehsullar uzerinde emeliyyat aparmaq");
                Console.WriteLine("2 - Satishlar uzerinde emeliyyat aparmaq");
                Console.WriteLine("3 - Sistemden chixmaq");
                Console.Write(Environment.NewLine + "Sechim edin: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        while (!sechim)
                        {
                            Console.WriteLine("1 - Yeni mehsul elave et");
                            Console.WriteLine("2 - Mehsul uzerinde duzelish et");
                            Console.WriteLine("3 - Mehsulu sil");
                            Console.WriteLine("4 - Butun mehsullari goster");
                            Console.WriteLine("5 - Kateqoriyaya uygun mehsullari goster");
                            Console.WriteLine("6 - Qiymet araligina gore mehsullari goster");
                            Console.WriteLine("7 - Ada gore mehsul axtar");
                            Console.WriteLine("8 - Esas menyuya qayitmaq");
                            Console.Write(Environment.NewLine + "Sechim edin: ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    methods.YeniMehsulElaveEtmek();
                                    break;
                                case "2":
                                    Console.Clear();
                                    methods.MehsulDetallariniDeyishmek();
                                    break;
                                case "3":
                                    Console.Clear();
                                    methods.MehsuluSil();
                                    break;
                                case "4":
                                    Console.Clear();
                                    methods.ButunMehsullariGoster();
                                    break;
                                case "5":
                                    Console.Clear();
                                    methods.VerilenKateqoriyadakiMehsullarinQaytarilmasi();
                                    break;
                                case "6":
                                    Console.Clear();
                                    methods.VerilmishQiymetAraligindakiMehsullarinQaytarilmasi();
                                    break;
                                case "7":
                                    Console.Clear();
                                    methods.AdaGoreMehsulunSechilmesi();
                                    break;
                                case "8":
                                    Console.Clear();
                                    sechim = true;
                                    break;
                                default:
                                    Console.WriteLine("Duzgun sechim edin.");
                                    break;
                            }
                        }
                        sechim = false;
                        break;
                    case "2":
                        Console.Clear();
                        while (!sechim)
                        {
                            Console.WriteLine("1 - Yeni satish elave et");
                            Console.WriteLine("2 - Satishdan mehsul chixartmaq");
                            Console.WriteLine("3 - Satishin silinmesi");
                            Console.WriteLine("4 - Butun satishlari goster");
                            Console.WriteLine("5 - Tarix araligina gore satishlari goster");
                            Console.WriteLine("6 - Mebleg araligina gore satishlari goster");
                            Console.WriteLine("7 - Deqiq tarixe uygun satishlari goster");
                            Console.WriteLine("8 - Nomresine uygun satishin melumatlarini goster");
                            Console.WriteLine("9 - Esas menyuya qayit");
                            Console.Write(Environment.NewLine + "Sechim edin: ");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.Clear();
                                    methods.SatishElaveEt();
                                    break;
                                case "2":
                                    Console.Clear();
                                    methods.SatishNomresineEsasenSatishinQaytarilmasi();
                                    break;
                                case "3":
                                    Console.Clear();
                                    methods.SatishiSil();
                                    break;
                                case "4":
                                    Console.Clear();
                                    methods.UmumiSatishinGeriQaytarilmasi();
                                    break;
                                case "5":
                                    Console.Clear();
                                    methods.TarixAraliginaGoreSatishlarinQaytarilmasi();
                                    break;
                                case "6":
                                    Console.Clear();
                                    methods.MeblegAraliginaGoreSatishlarinGeriQaytarilmasi();
                                    break;
                                case "7":
                                    Console.Clear();
                                    methods.KonkretTarixdeOlanSatishlarinQaytarilmasi();
                                    break;
                                case "8":
                                    Console.Clear();
                                    methods.SatishNomresineEsasenSatishinQaytarilmasi();
                                    break;
                                case "9":
                                    Console.Clear();
                                    sechim = true;
                                    break;
                                default:
                                    Console.WriteLine("Duzgun sechim edin.");
                                    break;
                            }
                        }
                        sechim = false;
                        break;
                    case "3":
                        myBool = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun sechim edin.");
                        break;
                }
            }
        }
    }
}
