using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string DailyPriceLimit = "Günlük fiyat tutarı yetersiz";
        public static string CarAdded = "Araba Kayıdı Eklendi";
        public static string CarDeleted = "Araba Kayıdı Silindi";
        public static string CarUpdated = "Araba Kayıdı Güncellendi";
        public static string CarListed = "Araba Kayıdı Bilgileri";
        public static string CarDetail = "Model / Renk / Fiyat bilgileri";

        public static string CustomerListed = "Müşteri Listesi";
        public static string CustomerAdded = "Müşteri Kayıdı Eklendi";
        public static string CustomerDeleted = "Müşteri Kayıdı Silindi";
        public static string CustomerUpdated = "Müşteri Kayıdı Güncellendi";

        public static string UserListed = "Kullanıcı Listesi";
        public static string UserAdded = "Kullanıcı Kayıdı Eklendi";
        public static string UserDeleted = "Kullanıcı Kayıdı Silindi";
        public static string UserUpdated = "Kullanıcı Kayıdı Güncellendi";

        public static string RentalListed = "Kiralama Listesi";
        public static string RentalAdded = "Kiralama Bilgileri Eklendi";
        public static string RentalDeleted = "Kiralama Bilgileri Silindi";
        public static string RentalUpdated = "Kiralama Bilgileri Güncellendi";
        public static string RentedCars = "Araba şuan kiralık";

        public static string BrandListed = "Marka Listesi";
        public static string BrandAdded = "Marka Bilgileri Eklendi";
        public static string BrandDeleted = "Marka Bilgileri Silindi";
        public static string BrandUpdated = "Marka Bilgileri Güncellendi";

        public static string ColorAdded = "Renk Eklendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Şifre hatalı";
        public static string UserAlreadyExists="Bu kullanıcı zaten mevcut";
        public static string UserRegistered="Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
