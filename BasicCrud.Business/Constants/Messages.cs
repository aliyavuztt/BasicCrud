namespace BasicCrud.Business.Constants
{
    public static class Messages
    {
        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir ürün bulunamadı.";
                return "Böyle bir ürün bulunamadı.";
            }
            public static string NotFoundById(int id)
            {
                return $"{id} ürün koduna ait bir ürün bulunamadı.";
            }
            public static string Add(string name)
            {
                return $"{name} adlı ürün başarıyla eklenmiştir.";
            }
            public static string Update(string name)
            {
                return $"{name} adlı ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string name)
            {
                return $"{name} adlı ürün başarıyla veritabanından silinmiştir.";
            }
            public static string NameAlreadyExists()
            {
                return $"Ürün adı daha önce eklenmiştir, Lütfen farklı ürün adı giriniz.";
            }
        }
    }
}