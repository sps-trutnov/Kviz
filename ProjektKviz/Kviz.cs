﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjektKviz
{
    public class Kviz
    {
        #region Pouzite pomocne datove struktury (pro vetsi pohodlnost psane jako class)
        public class Odpoved
        {
            public string ZneniOdpovedi { get; set; }
            public bool SpravnostOdpovedi { get; set; }
        }
        public class Otazka
        {
            public string ZneniOtazky { get; set; }
            public List<Odpoved> MozneOdpovedi { get; set; }
        }
        public class Vysledek
        {
            public string Prezdivka { get; set; }
            public uint Skore { get; set; }
        }
        #endregion

        #region Ukazka pomocne funkce
        public static void VypsatVysledky(List<Vysledek> vysledky, string prezdivkaHrace)
        {
            Console.WriteLine();
            Console.WriteLine(" Největší znalci Lakatoše ");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            foreach (Vysledek vysledek in vysledky)
            {
                string prezdivka = vysledek.Prezdivka;
                string skore = vysledek.Skore.ToString();

                string vyplnPrezdivky = Enumerable.Repeat<string>(" ", 15 + 1 - prezdivka.Length).Aggregate((skladanka, dalsi) => skladanka + dalsi);
                string vyplnSkore = Enumerable.Repeat<string>(" ", 1000.ToString().Length + 1 - skore.ToString().Length).Aggregate<string>((skladanka, dalsi) => skladanka + dalsi);

                string normovanaPrezdivka = prezdivka + vyplnPrezdivky;
                string normovaneSkore = vyplnSkore + skore;

                if (prezdivkaHrace != null && prezdivkaHrace == prezdivka)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(" " + normovanaPrezdivka + "   " + normovaneSkore);

                if (prezdivkaHrace != null && prezdivkaHrace == prezdivka)
                    Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void ZamichatOtazkamOdpovedi(List<Otazka> otazky)
        {
            foreach (Otazka otazka in otazky)
            {
                Random nahoda = new Random();

                for (int i = 0; i < otazka.MozneOdpovedi.Count; i++)
                {
                    int j = nahoda.Next(otazka.MozneOdpovedi.Count);

                    Odpoved o = otazka.MozneOdpovedi[i];
                    otazka.MozneOdpovedi[i] = otazka.MozneOdpovedi[j];
                    otazka.MozneOdpovedi[j] = o;
                }
            }
        }
        #endregion

        #region Funkce tymu (1) Landspersky + Hnyk + Korcak
        public static List<Otazka> NacistOtazky(string jmenoSouboru)
        {
            throw new NotImplementedException();
        }
        public static void ZamichatOtazky(List<Otazka> otazky)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Funkce tymu (2) Karas + Knizek + Jindra + Dzjubinskij
        public static void PolozitOtazku(Otazka otazka)
        {
            throw new NotImplementedException();
        }
        public static void NabidnoutOdpovedi(Otazka otazka)
        {
            throw new NotImplementedException();
        }
        public static int ZiskatOdpoved()
        {
            throw new NotImplementedException();
        }
        public static bool JeSpravnaOdpoved(int cisloOdpovedi, Otazka otazka)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Funkce tymu (3) Lukas + Hepnar + Krejcar
        public static List<Vysledek> NacistVysledky(string cestaSouboru)
        {
            throw new NotImplementedException();
        }
        public static bool JeDostatecneVysoke(uint skore, List<Vysledek> vysledky)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Funkce tymu (4) Gaspar + Janus + Janicek + Kabrt
        public static string ziskatPrezdivku()
        {
            Console.WriteLine("Zadejte přezdívku: ");
            string prezdivka = Console.ReadLine();

            return prezdivka;
        }

        public static void zaraditDoVysledku(string prezdivka, uint ziskaneSkore, List<Vysledek> vysledky)
        {

            vysledky.Count

            vysledky[pozice].zmenitSkore(skore);
            vysledky[pozice].zmenitPrezdivku(prezdivka);

        }

        public static void zapsatVysledky(List<Vysledek> vysledky, string cestaSouboru)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Hlavni program
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine(" V Í T E J T E   U   L A K A T O Š K V Í Z U ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();

            // ukol tymu (1) Landspersky + Hnyk + Korcak
            List<Otazka> otazky = NacistOtazky("kviz_data.txt");
            ZamichatOtazky(otazky);
            // -------------------------------------
            ZamichatOtazkamOdpovedi(otazky);

            int pocetLosovanychOtazek = Math.Min(10, otazky.Count);
            uint ziskaneSkore = 0;

            for (int i = 0; i < pocetLosovanychOtazek; i++)
            {
                // ukol tymu (2) Karas + Knizek + Jindra
                PolozitOtazku(otazky[i]);
                NabidnoutOdpovedi(otazky[i]);

                if (JeSpravnaOdpoved(ZiskatOdpoved(), otazky[i]))
                {
                    ziskaneSkore += 1;
                }
                // ---------------------------------
            }

            // ukol tymu (3) Lukas + Hepnar + Krejcar
            List<Vysledek> vysledky = NacistVysledky("kviz_skore.txt");
            bool umistilSe = JeDostatecneVysoke(ziskaneSkore, vysledky);
            // ----------------------------------

            // ukol tymu (4) Gaspar + Janus + Janicek + Kabrt
            string prezdivka = null;

            if (umistilSe)
            {
                prezdivka = ZiskatPrezdivku();
                ZaraditDoVysledku(prezdivka, ziskaneSkore, vysledky);
                ZapsatVysledky(vysledky, "kviz_skore.txt");
            }
            // ----------------------------------

            Console.Clear();
            VypsatVysledky(vysledky, prezdivka);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" (C) Ikonu vytvořil Freepik z webu www.flaticon.com");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine(" Děkujeme za zahrání!");

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
        #endregion
    }
}