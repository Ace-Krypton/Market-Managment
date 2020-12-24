using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement
{
    partial class MethodClass : IMarketable
    {
        List<Satish> satishlar = new List<Satish>();

        int satishID;
        int miqdar;

        DateTime tarix1 = new DateTime();
        DateTime tarix2 = new DateTime();

        public bool CheckID(Satish satish)
        {
            return satish.ID == satishID;
        }

        public void SatishElaveEt()
        {

            if (anbar.Count == 0 || anbar.TrueForAll(product => product.Count == 0))
            {
                Console.WriteLine("Anbar boshdur");
                return;
            }

            satishlar.Add(new Satish());

            Console.WriteLine("Satish detallarini daxil edin.");

            satishID = satishlar[satishlar.Count - 1].ID;

            while (true)
            {
                Console.Write("Tarix (format: ay/gun/il): ");

                if (String.IsNullOrEmpty(strInput.ToString()))
                    strInput.Append(Console.ReadLine());
                else
                    strInput.Replace(strInput.ToString(), Console.ReadLine());

                try
                {
                    satishlar.Find(CheckID).Tarix = DateTime.Parse(strInput.ToString());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun tarix daxil edin.");
                }
            }

            Console.WriteLine("Satisha elave etmek istediyiniz mehsul kodlarini daxil edin. Movcud mehsullarin siyahisi ashagidadir");
            Console.WriteLine("Satishi yekunlashdirmaq uchun 0 daxil edin.");

            ButunMehsullariGoster();

            while (true)
            {
                Console.Write("Mehsul kodu: ");

                if (String.IsNullOrEmpty(code.ToString()))
                    code.Append(Console.ReadLine());
                else
                    code.Replace(code.ToString(), Console.ReadLine());

                
                if (code.ToString() == "0")
                {
                    if (satishlar.Find(CheckID).Mebleg == 0)
                    {
                        Console.WriteLine("Satishin umumi meblegi 0 oldugu uchun elave olunmadi.");
                        satishlar.Remove(satishlar.Find(CheckID));
                        return;
                    }

                    Console.WriteLine("Satish yaradildi.");
                    Console.WriteLine(satishlar.Find(CheckID));
                    return;
                }

                if (String.IsNullOrEmpty(code.ToString()) ||
                  String.IsNullOrWhiteSpace(code.ToString()))
                {
                    Console.WriteLine("Duzgun mehsul kodu daxil edin!");
                    continue;
                }

                if (anbar.Find(MyMethod) == null)
                {
                    Console.WriteLine("Bu koda uygun mehsul tapilmadi. Novbeti mehsul kodunu daxil.");
                    continue;
                }

                if (anbar.Find(MyMethod).Count == 0)
                {
                    Console.WriteLine("Bu mehsul bitib. Novbeti mehsul kodunu daxil edin.");
                    continue;
                }

                if (satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)) != null)
                {
                    Console.WriteLine("Bu mehsuldan artiq elave etmisiniz. Movcud mehsul miqdarini yenilemek uchun + daxil edin.");
                    Console.WriteLine("Novbeti mehsula kechmek uchun her hansi bir herf daxil edin.");

                    Console.Write("Sechim edin: ");

                    if (String.IsNullOrEmpty(strInput.ToString()))
                        strInput.Append(Console.ReadLine());
                    else
                        strInput.Replace(strInput.ToString(), Console.ReadLine());

                    if (strInput.ToString() != "+")
                        continue;
                    else
                    {
                        Console.WriteLine("Mehsulun yeni miqdarini daxil edin");
                        satishlar.Find(CheckID).siyahi.Remove(satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)));
                    }

                }

                Console.WriteLine($"Bu mehsulun movcud sayi: {anbar.Find(MyMethod).Count}");
                Console.WriteLine("Alish miqdarini teyin edin.");

                while (true)
                {
                    Console.Write("Miqdar: ");

                    if (String.IsNullOrEmpty(strInput.ToString()))
                        strInput.Append(Console.ReadLine());
                    else
                        strInput.Replace(strInput.ToString(), Console.ReadLine());

                    if (strInput.ToString().Contains('.') || !int.TryParse(strInput.ToString(), out miqdar) || miqdar <= 0)
                    {
                        Console.WriteLine("Musbet tam eded daxil edin!");
                        continue;
                    }

                    if (anbar.Find(MyMethod).Count < miqdar)
                    {
                        Console.WriteLine("Istediyiniz miqdar movcud saydan choxdur. Yeni miqdar daxil edin.");
                        continue;
                    }

                    satishlar.Find(CheckID).siyahi.Add(new SatishItem(anbar.Find(MyMethod), miqdar));
                    satishlar.Find(CheckID).Mebleg += satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)).Product.Price * miqdar;
                    anbar.Find(MyMethod).Count -= miqdar;
                    Console.WriteLine("Novbeti mehsul kodunu daxil edin. Satishi yekunlashdirmaq uchun 0 daxil edin.");
                    break;
                }
            }
        }

        public void SatishNomresineEsasenSatishinQaytarilmasi()
        {
            if (satishlar.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                return;
            }

            Console.WriteLine("Deyishiklik etmek istediyiniz satishin nomresini daxil edin.");

            while (true)
            {
                if (satishlar.Count == 0)
                {
                    Console.WriteLine("Satish siyahisi boshdur");
                    return;
                }

                Console.Write("Satish Nomresi: ");

                if (String.IsNullOrEmpty(strInput.ToString()))
                    strInput.Append(Console.ReadLine());
                else
                    strInput.Replace(strInput.ToString(), Console.ReadLine());

                if (strInput.ToString().Contains('.') || !int.TryParse(strInput.ToString(), out satishID) || satishID <= 0)
                {
                    Console.WriteLine("Nomre musbet tam eded olmalidir.");
                    continue;
                }

                if (satishlar.Find(CheckID) == null)
                {
                    Console.WriteLine("Satish tapilmadi. Yeni satish nomresi daxil edin.");
                    continue;
                }

                Console.WriteLine("Geri qaytarmaq istediyiniz mehsulun kodunu ve sayini daxil edin.");
                Console.WriteLine("Emeliyyati yekunlashdirmaq uchun 0 daxil edin.");

                while (true)
                {
                    Console.Write("Kod: ");

                    if (String.IsNullOrEmpty(code.ToString()))
                        code.Append(Console.ReadLine());
                    else
                        code.Replace(code.ToString(), Console.ReadLine());

                    if (code.ToString() == "0")
                    {
                        Console.WriteLine("Emeliyyat dayandirildi.");
                        return;
                    }

                    if (satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)) == null)
                    {
                        Console.WriteLine("Satishda bu koda uygun mehsul yoxdur. Yeni kodu daxil edin.");
                        Console.WriteLine("Emeliyyati yekunlashdirmaq uchun 0 daxil edin.");
                        continue;
                    }

                    break;
                }

                while (true)
                {
                    Console.Write("Say: ");

                    if (String.IsNullOrEmpty(strInput.ToString()))
                        strInput.Append(Console.ReadLine());
                    else
                        strInput.Replace(strInput.ToString(), Console.ReadLine());

                    if (code.ToString() == "0")
                    {
                        Console.WriteLine("Emeliyyat dayandirildi.");
                        return;
                    }

                    if (strInput.ToString().Contains('.') || !int.TryParse(strInput.ToString(), out miqdar) || miqdar <= 0)
                    {
                        Console.WriteLine("Musbet tam eded daxil edin!");
                        continue;
                    }

                    if (satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)).Count < miqdar)
                    {
                        Console.WriteLine("Satishda bu qeder mehsul movcud deyil. Yeni miqdar daxil edin.");
                        continue;
                    }

                    break;
                }

                satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)).Count -= miqdar;
                satishlar.Find(CheckID).Mebleg -= satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)).Product.Price * miqdar;
                anbar.Find(MyMethod).Count += miqdar;
                Console.WriteLine("Mehsul qaytarildi");
                Console.WriteLine("Satishin cari veziyyeti");
                Console.WriteLine(satishlar.Find(CheckID));
                break;
            }

            if (satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)).Count == 0)
                satishlar.Find(CheckID).siyahi.Remove(satishlar.Find(CheckID).siyahi.Find(item => item.Product == anbar.Find(MyMethod)));
        }

        public void SatishiSil()
        {
            if (satishlar.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                return;
            }

            Console.WriteLine("Silmek istediyiniz satishin nomresini daxil edin.");

            while (true)
            {
                Console.Write("Nomre: ");

                if (String.IsNullOrEmpty(strInput.ToString()))
                    strInput.Append(Console.ReadLine());
                else
                    strInput.Replace(strInput.ToString(), Console.ReadLine());

                if (strInput.ToString().Contains('.') || !int.TryParse(strInput.ToString(), out satishID) || satishID <= 0)
                {
                    Console.WriteLine("Nomre musbet tam eded olmalidir.");
                    continue;
                }

                if (satishlar.Find(CheckID) == null)
                {
                    Console.WriteLine("Satish tapilmadi. Yeni satish nomresi daxil edin.");
                    continue;
                }

                satishlar.Remove(satishlar.Find(CheckID));
                Console.WriteLine("Satish silindi");
                return;
            }
        }

        public void UmumiSatishinGeriQaytarilmasi()
        {
            if (satishlar.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                return;
            }

            Console.WriteLine("Umumi satish siyahisi:");

            foreach (Satish item in satishlar)
                Console.WriteLine(item);
        }

        public void TarixAraliginaGoreSatishlarinQaytarilmasi()
        {
            if (satishlar.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                return;
            }

            Console.WriteLine("Tarix araligi daxil edin. (format: ay/gun/il)");

            while (true)
            {
                try
                {
                    Console.Write("Bashlangic: ");
                    tarix1 = DateTime.Parse(Console.ReadLine());
                    Console.Write("Son: ");
                    tarix2 = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun tarixler daxil edin.");
                }
            }

            if (satishlar.Find(x => x.Tarix >= tarix1 && x.Tarix <= tarix2) == null)
            {
                Console.WriteLine("Bu tarix araligina uygun satish movcud deyil");
                return;
            }

            foreach (Satish item in satishlar.FindAll(x => x.Tarix >= tarix1 && x.Tarix <= tarix2))
                Console.WriteLine(item);
        }

        public void MeblegAraliginaGoreSatishlarinGeriQaytarilmasi()
        {
            if (satishlar.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                return;
            }

            while (true)
            {
                Console.Write("Minimum qiymet daxil edin: ");
                minPriceInput.Append(Console.ReadLine());
                Console.Write("Maximum qiymet daxil edin: ");
                maxPriceInput.Append(Console.ReadLine());

                if (!double.TryParse(minPriceInput.ToString(), out minPrice) || minPrice < 0 ||
                    !double.TryParse(maxPriceInput.ToString(), out maxPrice) || maxPrice < 0 && minPrice > maxPrice)
                {
                    Console.WriteLine("Duzgun qiymet araligi daxil edin.");
                    minPriceInput.Clear();
                    maxPriceInput.Clear();
                    continue;
                }

                if (satishlar.Find(satish => satish.Mebleg >= minPrice && satish.Mebleg <= maxPrice) == null)
                {
                    Console.WriteLine("Bu qiymet araliginda mehsul yoxdur.");
                    return;
                }

                foreach (Satish item in satishlar.FindAll(satish => satish.Mebleg >= minPrice && satish.Mebleg <= maxPrice))
                    Console.WriteLine(item);

                break;
            }
        }

        public void KonkretTarixdeOlanSatishlarinQaytarilmasi()
        {
            if (satishlar.Count == 0)
            {
                Console.WriteLine("Satish siyahisi boshdur");
                return;
            }

            Console.WriteLine("Tarix daxil edin. (format: ay/gun/il): ");

            while (true)
            {
                try
                {
                    tarix1 = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun tarixler daxil edin.");
                }
            }

            if (satishlar.Find(x => x.Tarix == tarix1) == null)
            {
                Console.WriteLine("Bu tarixe uygun satish movcud deyil");
                return;
            }

            foreach (Satish item in satishlar.FindAll(x => x.Tarix == tarix1))
                Console.WriteLine(item);
        }
    }
}