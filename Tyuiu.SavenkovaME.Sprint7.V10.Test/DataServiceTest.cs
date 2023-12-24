using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.SavenkovaME.Sprint7.V10.Lib;

namespace Tyuiu.SavenkovaME.Sprint7.V10.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidProduct()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\saven\OneDrive\Рабочий стол\прога\Files\Товары.csv";
            string[,] wait = new string[,] { {"Товар","Код товара","Стоимость"},
                {"Ноутбук MSI GL73 8RD","1","99990" }, { "Беспроводная игровая мышь с Bluetooth","2","990"},
                { "Мультимедийная игровая клавиатура Ombar","3","4990"}};
            string[,] res = ds.LoadFromData(path);
            CollectionAssert.AreEqual(wait, res);
        }
    }
}
