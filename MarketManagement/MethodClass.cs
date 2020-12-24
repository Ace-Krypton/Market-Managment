using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MarketManagement
{
    partial class MethodClass : IMarketable
    {
        List<Product> anbar = new List<Product>();

        StringBuilder code = new StringBuilder("default");
        StringBuilder newCode = new StringBuilder("default");
        StringBuilder strInput = new StringBuilder("default");

        StringBuilder minPriceInput = new StringBuilder();
        StringBuilder maxPriceInput = new StringBuilder();

        double minPrice;
        double maxPrice;

        double price;
        int count;
        bool category = false;

        public bool MyMethod(Product item)
        {
            return item.Code == code.ToString();
        }

        public bool NewCode(Product item)
        {
            return item.Code == newCode.ToString();
        }

        public void YeniMehsulElaveEtmek()
        {
            anbar.Add(new Product());
            Console.WriteLine("Mehsul detallarini daxil edin.");

            while (true)
            {
                Console.Write("Mehsulun kodu: ");
                code.Replace(code.ToString(), Console.ReadLine());

                if (anbar.Exists(MyMethod))
                {
                    Console.WriteLine("Bu kodlu mehsul artiq movcuddur.");
                    return;
                }

                if (code.ToString() == "0")
                {
                    Console.WriteLine("Mehsul kodu 0 ola bilmez.");
                    continue;
                }

                if (!String.IsNullOrEmpty(code.ToString()) &&
                    !String.IsNullOrWhiteSpace(code.ToString()))
                {
                    anbar[anbar.Count - 1].Code = code.ToString();
                    break;
                }

                Console.WriteLine("Bosh buraxila bilmez.");
                code.Append("default");
            }

            while (true)
            {
                Console.Write("Mehsulun adi: ");
                strInput.Replace(strInput.ToString(), Console.ReadLine());

                if (!String.IsNullOrEmpty(strInput.ToString()) &&
                    !String.IsNullOrWhiteSpace(strInput.ToString()))
                {
                    anbar.Find(MyMethod).Name = strInput.ToString();
                    break;
                }

                Console.WriteLine("Bosh buraxila bilmez.");
                strInput.Append("default");
            }

            while (true)
            {
                Console.Write("Mehsulun qiymeti: ");
                
                if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    anbar.Find(MyMethod).Price = price;
                    break;
                }

                Console.WriteLine("Duzgun qiymet daxil edin.");
            }

            while (true)
            {
                Console.Write("Mehsulun sayi: ");

                if (int.TryParse(Console.ReadLine(), out count) && count >= 0)
                {
                    anbar.Find(MyMethod).Count = count;
                    Console.WriteLine("Mehsul uchun ashagidaki kateqoriyalardan birini sechin.");

                    foreach (var item in Enum.GetValues(typeof(Category)))
                        Console.WriteLine($"{(int)item} - {item}");

                    break;
                }

                Console.WriteLine("Zehmet olmasa duzgun say daxil edin.");
            }

            while (!category)
            {
                Console.Write("Kateqoriya indeksi: ");
                strInput.Replace(strInput.ToString(), Console.ReadLine());

                switch (strInput.ToString())
                {
                    case "1":
                        anbar.Find(MyMethod).Category = Category.Shirniyyat;
                        category = true;
                        break;
                    case "2":
                        anbar.Find(MyMethod).Category = Category.Meyve_Terevez;
                        category = true;
                        break;
                    case "3":
                        anbar.Find(MyMethod).Category = Category.Ichki;
                        category = true;
                        break;
                    case "4":
                        anbar.Find(MyMethod).Category = Category.Et;
                        category = true;
                        break;
                    case "5":
                        anbar.Find(MyMethod).Category = Category.Meishet;
                        category = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya nomresi daxil edin.");
                        strInput.Append("default");
                        break;
                }
            }

            Console.WriteLine("Mehsul elave edildi.");
            Console.WriteLine(anbar.Find(MyMethod));
            category = false;
        }

        public void MehsulDetallariniDeyishmek()
        {
            Console.Write("Deyishmek istediyiniz mehsulun kodunu daxil edin: ");
            code.Replace(code.ToString(), Console.ReadLine());

            if (!anbar.Exists(MyMethod))
            {
                Console.WriteLine("Bu kodlu mehsul yoxdur");
                code.Append("default");
                return;
            }

            while (true)
            {
                Console.Write("Mehsulun yeni kodu: ");
                newCode.Replace(newCode.ToString(), Console.ReadLine());

                if (anbar.Exists(NewCode))
                {
                    Console.WriteLine("Bu kod artiq istifade olunub.");
                    return;
                }

                if (newCode.ToString() == "0")
                {
                    Console.WriteLine("Mehsul kodu 0 ola bilmez.");
                    continue;
                }

                if (!String.IsNullOrEmpty(newCode.ToString()) &&
                    !String.IsNullOrWhiteSpace(newCode.ToString()))
                {
                    anbar.Find(MyMethod).Code = newCode.ToString();
                    break;
                }

                Console.WriteLine("Bosh buraxila bilmez.");
                newCode.Append("default");
            }

            while (true)
            {
                Console.Write("Mehsulun yeni adi: ");
                strInput.Replace(strInput.ToString(), Console.ReadLine());

                if (!String.IsNullOrEmpty(strInput.ToString()) &&
                    !String.IsNullOrWhiteSpace(strInput.ToString()))
                {
                    anbar.Find(NewCode).Name = strInput.ToString();
                    break;
                }

                Console.WriteLine("Bosh buraxila bilmez.");
                strInput.Append("default");
            }

            while (true)
            {
                Console.Write("Mehsulun yeni qiymeti: ");

                if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    anbar.Find(NewCode).Price = price;
                    break;
                }

                Console.WriteLine("Duzgun qiymet daxil edin.");
            }

            while (true)
            {
                Console.Write("Mehsulun yeni sayi: ");

                if (int.TryParse(Console.ReadLine(), out count) && count >= 0)
                {
                    anbar.Find(NewCode).Count = count;
                    Console.WriteLine("Mehsul uchun yeni kateqoriya sechin.");

                    foreach (var item in Enum.GetValues(typeof(Category)))
                        Console.WriteLine($"{(int)item} - {item}");

                    break;
                }

                Console.WriteLine("Duzgun say daxil edin.");
            }

            while (!category)
            {
                Console.Write("Kateqoriya indeksi: ");
                strInput.Replace(strInput.ToString(), Console.ReadLine());

                switch (strInput.ToString())
                {
                    case "1":
                        anbar.Find(NewCode).Category = Category.Shirniyyat;
                        category = true;
                        break;
                    case "2":
                        anbar.Find(NewCode).Category = Category.Meyve_Terevez;
                        category = true;
                        break;
                    case "3":
                        anbar.Find(NewCode).Category = Category.Ichki;
                        category = true;
                        break;
                    case "4":
                        anbar.Find(NewCode).Category = Category.Et;
                        category = true;
                        break;
                    case "5":
                        anbar.Find(NewCode).Category = Category.Meishet;
                        category = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya nomresi daxil edin.");
                        strInput.Append("default");
                        break;
                }
            }

            Console.WriteLine("Mehsul detallari deyishdirildi.");
            Console.WriteLine(anbar.Find(NewCode));
            category = false;
        }

        public void MehsuluSil()
        {
            Console.Write("Silmek istediyiniz mehsulun Kodunu Daxil edin: ");
            code.Replace(code.ToString(), Console.ReadLine());

            if (!anbar.Exists(MyMethod))
            {
                Console.WriteLine("Bu koda uygun mehsul tapilmadi.");
                code.Append("default");
                return;
            }

            anbar.Remove(anbar.Find(MyMethod));
            Console.WriteLine("Mehsul silindi.");
        }

        public void ButunMehsullariGoster()
        {
            if (anbar.Count == 0)
            {
                Console.WriteLine("Anbar boshdur.");
                return;
            }

            Console.WriteLine("Anbardaki mehsullar");

            foreach (Product item in anbar)
                Console.WriteLine(item);
        }

        public void VerilenKateqoriyadakiMehsullarinQaytarilmasi()
        {
            Console.WriteLine("Kateqoriyaya uygun mehsullari goster.");

            foreach (var item in Enum.GetValues(typeof(Category)))
                Console.WriteLine($"{(int)item} - {item}");

            while (!category)
            {
                Console.Write("Kateqoriya indeksi: ");
                strInput.Replace(strInput.ToString(), Console.ReadLine());

                switch (strInput.ToString())
                {
                    case "1":
                        if (anbar.Find(product => product.Category == Category.Shirniyyat) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in anbar.FindAll(product => product.Category == Category.Shirniyyat))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "2":
                        if (anbar.Find(product => product.Category == Category.Meyve_Terevez) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in anbar.FindAll(product => product.Category == Category.Meyve_Terevez))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "3":
                        if (anbar.Find(product => product.Category == Category.Ichki) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in anbar.FindAll(product => product.Category == Category.Ichki))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "4":
                        if (anbar.Find(product => product.Category == Category.Et) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in anbar.FindAll(product => product.Category == Category.Et))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    case "5":
                        if (anbar.Find(product => product.Category == Category.Meishet) == null)
                        {
                            Console.WriteLine("Bu kateqoriyaya uygun mehsul tapilmadi.");
                            return;
                        }

                        foreach (Product item in anbar.FindAll(product => product.Category == Category.Meishet))
                            Console.WriteLine(item);

                        category = true;
                        break;
                    default:
                        Console.WriteLine("Duzgun kateqoriya nomresi daxil edin.");
                        strInput.Append("default");
                        break;
                }
            }

            category = false;
        }

        public void VerilmishQiymetAraligindakiMehsullarinQaytarilmasi()
        {
            Console.Write("Minimum qiymet daxil edin: ");
            minPriceInput.Append(Console.ReadLine());
            Console.Write("Maximum qiymet daxil edin: ");
            maxPriceInput.Append(Console.ReadLine());

            if (double.TryParse(minPriceInput.ToString(), out minPrice) && minPrice > 0 &&
                double.TryParse(maxPriceInput.ToString(), out maxPrice) && maxPrice > 0 && minPrice < maxPrice)
            {
                if (anbar.Find(product => product.Price >= minPrice && product.Price <= maxPrice) == null)
                {
                    Console.WriteLine("Bu qiymet araliginda mehsul yoxdur.");
                    return;
                }

                foreach (Product item in anbar.FindAll(product => product.Price >= minPrice && product.Price <= maxPrice))
                    Console.WriteLine(item);

                return;
            }

            Console.WriteLine("Daxil etdiyiniz qiymet araligi yalnishdir.");

            minPriceInput.Clear();
            maxPriceInput.Clear();
        }

        public void AdaGoreMehsulunSechilmesi()
        {
            Console.Write("Mehsul adini daxil edin: ");
            strInput.Replace(strInput.ToString(), Console.ReadLine());

            if (anbar.Find(product => product.Name.ToLower() == strInput.ToString().ToLower()) == null)
            {
                Console.WriteLine("Bu ada uygun mehsul tapilmadi.");
                strInput.Append("default");
                return;
            }

            foreach (Product item in anbar.FindAll(product => product.Name.ToLower() == strInput.ToString().ToLower()))
                Console.WriteLine(item);
        }
    }
}
