using PlugInSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatExercise.Entities;

namespace VatExercise
{
    public class VatExerciseClasses: AExercise
    {
        public override string Description => "Calcolo dell'IVA usando il potere delle classi";

        public override Version VersionNumber => new Version(3,0);

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

        public override void Run(IGUI guiHandler)
        {
            _guiHandler = guiHandler ?? throw new ArgumentNullException(nameof(guiHandler));
            bool _exit = false;

            List<AVAT> availableVATS = GenerateMockList();
            AVAT selectedVAT = null;

            //List<Option> options = new List<Option>();
            //options.Add(new Option() {Code = "1", Description = "Seleziona P.IVA", Operation = SelectVAT });

            ShowMain();
            while (!_exit)
            {
                Options option = ReadOption(selectedVAT);
                switch (option)
                {
                    default:
                        ///NON DOVREBBE MAI ACCADERE
                        break;
                    case Options.SelezionaPartitaIVA:
                        selectedVAT = SelectVAT(availableVATS);
                        break;
                    case Options.AggiungiBill:
                        if (IsVATSelected(ref selectedVAT, availableVATS))
                        {
                            decimal bill = _guiHandler.AskForDecimal("Inserisci il valore della bill da aggiungere: ");
                            if (bill > 0)
                            {
                                selectedVAT.AddBill(bill);
                            }
                        }
                        break;
                    case Options.AggiungiExpense:
                        if (IsVATSelected(ref selectedVAT, availableVATS))
                        {                            
                            decimal expence = _guiHandler.AskForDecimal("Inserisci il valore della spesa da aggiungere: ");
                            if (expence > 0)
                            {
                                try
                                {
                                    selectedVAT.AddExpense(expence);
                                }
                                catch (Exception)
                                {
                                    _guiHandler.WriteMessage($"Non posso aggiungere una spesa a questo tipo di P.IVA ({selectedVAT.GetType().Name})", Color.Orange);
                                    _guiHandler.AskForKey(true);
                                }
                            }                            
                        }
                        break;
                    case Options.CalcolaGuadagnoNetto:
                        if (IsVATSelected(ref selectedVAT, availableVATS))
                        {
                            _guiHandler.WriteMessage(selectedVAT.CalculateAndPrint());
                            _guiHandler.AskForKey(true);
                        }
                        break;
                    case Options.ElencaPartiteIVA:
                        ShowAvailableVATS(availableVATS);
                        _guiHandler.AskForKey(true);
                        break;
                    case Options.Exit:
                        _exit = true;
                        return;
                }

               // _exit = _guiHandler.AskForExit();
            }
        }

        private List<AVAT> GenerateMockList()
        {
            List<AVAT> outList = new List<AVAT>();
            outList.Add(new VAT_Normal() { VatNumber = 123456 });
            outList.Add(new VAT_Normal() { VatNumber = 654321 });
            outList.Add(new VAT_Normal() { VatNumber = 123789 });
            outList.Add(new VAT_Normal() { VatNumber = 789321 });
            outList.Add(new VAT_Normal() { VatNumber = 456321 });
            outList.Add(new VAT_Normal() { VatNumber = 987654 });
            
            outList.Add(new VAT_Simple() { VatNumber = 753951 });
            outList.Add(new VAT_Simple() { VatNumber = 159357 });
            outList.Add(new VAT_Simple() { VatNumber = 258456 });
            outList.Add(new VAT_Simple() { VatNumber = 654852 });

            return outList;
        }

        private bool IsVATSelected(ref AVAT selectedVAT, List<AVAT> availableVATS)
        {
            while(selectedVAT == null)
            {
                _guiHandler.WriteMessage("Non è stata selezionata nessuna P.IVA!", Color.Red);
                selectedVAT = SelectVAT(availableVATS);
            }
            return true;
        }

        private AVAT SelectVAT(List<AVAT> availableVATS)
        {
            AVAT selectedVAT = null;
            while(selectedVAT is null)
            {                
                bool converted = int.TryParse(_guiHandler.AskForText("Seleziona una P.IVA: "), out int userSelection);
                if (converted)
                {
                    ///Ricerca se P.IVA in lista
                    foreach (var vat in availableVATS)
                    {
                        if (vat.VatNumber == userSelection)
                        {
                            selectedVAT = vat;
                            break;
                        }
                    }
                }
                if (!converted || selectedVAT == null)
                {
                    _guiHandler.WriteMessage("La tua selezione non corrisponde ad una P.IVA disponibile", Color.Red);
                    ShowAvailableVATS(availableVATS);
                }
            }

            return selectedVAT;
        }

        private void ShowAvailableVATS(List<AVAT> availableVATS)
        {
            _guiHandler.WriteMessage("P.IVA disponibili: ");
            _guiHandler.WriteMessage();
            List <Color> colors = new List<Color>() { Color.LightGray, Color.White };
            int i = 0;
            foreach (var vat in availableVATS)
            {
                _guiHandler.WriteMessage($"{vat.GetType().Name}: { vat.VatNumber}", colors[i%2]);
                i++;
            }
        }

        private Options ReadOption(AVAT selectedVAT)
        {
            Options selectedOption = 0;
            while (selectedOption == 0)
            {
                ShowMain();
                ShowSelectedVAT(selectedVAT);

                _guiHandler.WriteMessage("****************************************");
                _guiHandler.WriteMessage("1) Seleziona P.IVA");
                _guiHandler.WriteMessage("2) Aggiungi Bill a P.IVA");
                _guiHandler.WriteMessage("3) Aggiungi Expense a P.IVA");
                _guiHandler.WriteMessage("4) Calcola guadagno netto");
                _guiHandler.WriteMessage("5) Elenca tutte le P.IVA");
                _guiHandler.WriteMessage("6) Esci");
                _guiHandler.WriteMessage("****************************************");

                _guiHandler.WriteMessage();
                _guiHandler.WriteMessage("Seleziona un opzione: ");

                bool validConversion = int.TryParse(Console.ReadLine(), out int userSelection);
                if (!validConversion || userSelection < 1 || userSelection > 6)
                {
                    selectedOption = 0;
                    _guiHandler.WriteMessage("L'opzione selezionata non è valida!", Color.Red);
                    Console.ReadKey(true);
                }
                else
                {
                    selectedOption = (Options)userSelection;
                }
            }
            return selectedOption;
        }

        private void ShowSelectedVAT(AVAT selectedVAT)
        {
            int selPIVA = 0;
            if (selectedVAT != null)
                selPIVA = selectedVAT.VatNumber;
            if (selPIVA != 0)
            {
                _guiHandler.WriteMessage($" - La P.IVA selezionata è: {selPIVA} -", Color.Green);
                _guiHandler.WriteMessage();
            }
        }

        private void ShowMain()
        {            
            _guiHandler.ClrScr();
            _guiHandler.WriteMessage("****************************************", Color.Yellow);
            _guiHandler.WriteMessage("*****         VAT MANAGER          *****", Color.Yellow);
            _guiHandler.WriteMessage("****************************************", Color.Yellow);
            _guiHandler.WriteMessage();
        }
    }
}
