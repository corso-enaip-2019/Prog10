using PlugInSystem;
using StarWars2_Delegates.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars2_Delegates
{
    public class StarWarsMain : AExercise
    {
        public override string Description => throw new NotImplementedException();

        public override Version VersionNumber => throw new NotImplementedException();

        public override void Run(IGUI guiHandler)
        {

            Mum leila = new Mum("Leila");
            Dad hanSolo = new Dad("Han Solo");
            Robot r2d2 = new Robot("R2D2");
            Baby benSolo = leila.MakeBaby(hanSolo, "Ben Solo");
            //benSolo.AddComforter(r2d2.Comfort);

            benSolo.StartCrying();
            benSolo.StartCrying();
            benSolo.StartCrying();
            benSolo.StartCrying();
            benSolo.StartCrying();

            benSolo.AddComforter(TheForce.ComfortChild);
            benSolo.StartCrying();


            Console.ReadKey();
        }
    }
}
