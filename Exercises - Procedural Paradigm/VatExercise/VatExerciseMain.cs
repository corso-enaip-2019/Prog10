using PlugInSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatExercise.Entities;

namespace VatExercise
{
    public class VatExerciseMain : AExercise
    {
        enum Options
        {
            Null = 0,
            SelezionaPartitaIVA = 1,
            AggiungiBill = 2,
            AggiungiExpense = 3,
            CalcolaGuadagnoNetto = 4,
            ElencaPartiteIVA = 5,
            Exit = 6,
        }


        public override string Description => "Calcolo dell'IVA";

        public override Version VersionNumber => new Version(1, 0);

        public override void Run(IGUI guiHandler)
        {
            //_guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));

            List<VAT_Normal> _lstNormalVAT = new List<VAT_Normal>();
            List<VAT_Simple> _lstSimpleVAT = new List<VAT_Simple>();

            #region EXAMPLE LIST INIT
            _lstNormalVAT.Add(new VAT_Normal() { VatNumber = 123456, Bills = new List<decimal>(), Expenses = new List<decimal>() });
            _lstNormalVAT.Add(new VAT_Normal() { VatNumber = 654321, Bills = new List<decimal>(), Expenses = new List<decimal>() });
            _lstNormalVAT.Add(new VAT_Normal() { VatNumber = 123789, Bills = new List<decimal>(), Expenses = new List<decimal>() });
            _lstNormalVAT.Add(new VAT_Normal() { VatNumber = 789321, Bills = new List<decimal>(), Expenses = new List<decimal>() });
            _lstNormalVAT.Add(new VAT_Normal() { VatNumber = 456321, Bills = new List<decimal>(), Expenses = new List<decimal>() });
            _lstNormalVAT.Add(new VAT_Normal() { VatNumber = 987654, Bills = new List<decimal>(), Expenses = new List<decimal>() });

            _lstSimpleVAT.Add(new VAT_Simple() { VatNumber = 753951, Bills = new List<decimal>() });
            _lstSimpleVAT.Add(new VAT_Simple() { VatNumber = 159357, Bills = new List<decimal>() });
            _lstSimpleVAT.Add(new VAT_Simple() { VatNumber = 258456, Bills = new List<decimal>() });
            _lstSimpleVAT.Add(new VAT_Simple() { VatNumber = 654852, Bills = new List<decimal>() });
            #endregion EXAMPLE LIST INIT

            VAT_Normal _selected_NormalVat = null;
            VAT_Simple _selected_SimpleVat = null;

            bool exit = false;
            while (!exit) ///MAIN EXECUTION LOOP
            {
                ///SELEZIONE OPZIONI
                Options selectedOption = 0;
                while (selectedOption == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("****************************************");
                    Console.WriteLine("*****         VAT MANAGER          *****");
                    Console.WriteLine("****************************************");
                    Console.WriteLine();

                    int selPIVA = 0;
                    if (_selected_NormalVat != null)
                        selPIVA = _selected_NormalVat.VatNumber;
                    if (_selected_SimpleVat != null)
                        selPIVA = _selected_SimpleVat.VatNumber;
                    if (selPIVA != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" - La P.IVA selezionata è: {selPIVA} -");
                        Console.WriteLine();
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("****************************************");
                    Console.WriteLine("1) Seleziona P.IVA");
                    Console.WriteLine("2) Aggiungi Bill a P.IVA");
                    Console.WriteLine("3) Aggiungi Expense a P.IVA");
                    Console.WriteLine("4) Calcola guadagno netto");
                    Console.WriteLine("5) Elenca tutte le P.IVA");
                    Console.WriteLine("6) Esci");
                    Console.WriteLine("****************************************");

                    Console.WriteLine();
                    Console.Write("Seleziona un opzione: ");

                    bool validConversion = int.TryParse(Console.ReadLine(), out int userSelection);
                    if (!validConversion || userSelection < 1 || userSelection > 6)
                    {
                        selectedOption = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("L'opzione selezionata non è valida!");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        selectedOption = (Options)userSelection;
                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (selectedOption)
                {
                    default:
                        ///SE SOPRA FUNZIONA TUTTO NON DOVREI MAI ENTRARE QUI DENTRO
                        ///NON FACCIO NULLA E RICICLO
                        break;
                    case Options.SelezionaPartitaIVA:
                        #region selezione P.IVA
                        while (_selected_NormalVat == null && _selected_SimpleVat == null)
                        {
                            _selected_NormalVat = null;
                            _selected_SimpleVat = null;
                            Console.Write("Seleziona una P. IVA: ");
                            bool converted = int.TryParse(Console.ReadLine(), out int userSelection);
                            if (converted)
                            {
                                ///Ricerca se P.IVA in lista
                                foreach (var vat in _lstNormalVAT)
                                {
                                    if (vat.VatNumber == userSelection)
                                    {
                                        _selected_NormalVat = vat;
                                        break;
                                    }
                                }
                                foreach (var vat in _lstSimpleVAT)
                                {
                                    if (vat.VatNumber == userSelection)
                                    {
                                        _selected_SimpleVat = vat;
                                        break;
                                    }
                                }
                            }
                            if (!converted || (_selected_NormalVat == null && _selected_SimpleVat == null))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("La tua selezione non corrisponde ad una P.IVA disponibile");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                ///Lista P.IVA disponibili
                                Console.WriteLine("P.IVA disponibili: ");
                                foreach (var vat in _lstNormalVAT)
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write($"Normal VAT: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(vat.VatNumber);
                                }
                                foreach (var vat in _lstSimpleVAT)
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write($"Normal VAT: ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(vat.VatNumber);
                                }
                            }
                        }

                        if (_selected_NormalVat != null)
                        {
                            Console.WriteLine($"La P.IVA selezionata è: {_selected_NormalVat.VatNumber}");
                        }
                        if (_selected_SimpleVat != null)
                        {
                            Console.WriteLine($"La P.IVA selezionata è: {_selected_SimpleVat.VatNumber}");
                        }
                        break;
                    #endregion selezione P.IVA
                    case Options.AggiungiBill:
                        if (_selected_NormalVat == null && _selected_SimpleVat == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ATTENZIONE!!!!");
                            Console.WriteLine("Non hai selezionato nessuna P.IVA!");
                        }
                        else
                        {
                            bool validInput = false;
                            while (!validInput)
                            {
                                Console.Write("Inserisci il valore della fattura: ");
                                validInput = decimal.TryParse(Console.ReadLine(), out decimal inputBill);
                                if (validInput)
                                {
                                    if (_selected_NormalVat != null)
                                    {
                                        _selected_NormalVat.Bills.Add(inputBill);
                                    }
                                    if (_selected_SimpleVat != null)
                                    {
                                        _selected_SimpleVat.Bills.Add(inputBill);
                                    }
                                }
                            }
                        }
                        break;
                    case Options.AggiungiExpense:

                        if (_selected_NormalVat == null && _selected_SimpleVat == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ATTENZIONE!!!!");
                            Console.WriteLine("Non hai selezionato nessuna P.IVA!");
                        }
                        else if (_selected_SimpleVat != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ATTENZIONE!!!!");
                            Console.WriteLine("La P.IVA selezionata non ammette l'aggiunta di spese!");
                        }
                        else
                        {
                            bool validInput = false;
                            while (!validInput)
                            {
                                Console.Write("Inserisci il valore della spesa: ");
                                validInput = decimal.TryParse(Console.ReadLine(), out decimal inputExpense);
                                if (validInput)
                                {
                                    if (_selected_NormalVat != null)
                                    {
                                        _selected_NormalVat.Expenses.Add(inputExpense);
                                    }
                                }
                            }
                        }
                        break;
                    case Options.CalcolaGuadagnoNetto:
                        if (_selected_NormalVat == null && _selected_SimpleVat == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ATTENZIONE!!!!");
                            Console.WriteLine("Non hai selezionato nessuna P.IVA!");
                        }
                        else
                        {
                            if (_selected_NormalVat != null)
                            {

                            }
                            if (_selected_SimpleVat != null)
                            {

                            }
                        }
                        break;
                    case Options.ElencaPartiteIVA:
                        ///Lista P.IVA disponibili
                        Console.WriteLine("P.IVA disponibili: ");
                        foreach (var vat in _lstNormalVAT)
                        {
                            Console.WriteLine($"Normal VAT - {vat.VatNumber}");
                        }
                        foreach (var vat in _lstSimpleVAT)
                        {
                            Console.WriteLine($"Simple VAT - {vat.VatNumber}");
                        }
                        break;
                    case Options.Exit:
                        exit = true;
                        break;
                }

                Console.ReadKey(true);
            }

        }
    }
}
