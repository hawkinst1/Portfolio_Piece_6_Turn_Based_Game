using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Wisps
{
    public class game
    {
        public static void creaturegen()
        {
            List<string> typegen = new List<string>();

            typegen.Add("Air");
            typegen.Add("Water");
            typegen.Add("Flora");
            typegen.Add("Fire");
            typegen.Add("Timber");
            typegen.Add("Terra");
            typegen.Add("Mineral");
            typegen.Add("Metal");
            typegen.Add("Ice");
            typegen.Add("Spirit");
            typegen.Add("Quicksilver");
            typegen.Add("Chemical");
            typegen.Add("Light");
            typegen.Add("Liquid Gold");
            typegen.Add("Lightning");
            typegen.Add("Tar");
            typegen.Add("Acid");

            typegen.Sort();
            string concat = string.Join("\n", typegen);

            List<string> referenceNature = new List<string>();

            referenceNature.Add("Land bird");
            referenceNature.Add("Raptor");
            referenceNature.Add("Owl");
            referenceNature.Add("Gull");
            referenceNature.Add("Hummingbird");
            referenceNature.Add("Parrot");
            referenceNature.Add("Bird of Paradise");
            referenceNature.Add("Bipedal mammal");
            referenceNature.Add("Deer");
            referenceNature.Add("Feline");
            referenceNature.Add("Canine");
            referenceNature.Add("Amphibian");
            referenceNature.Add("Crustacean");
            referenceNature.Add("Worm");
            referenceNature.Add("Flat insect");
            referenceNature.Add("Whale");
            referenceNature.Add("Shark");
            referenceNature.Add("Coral fish ");
            referenceNature.Add("Winged insect");
            referenceNature.Add("Floral");
            referenceNature.Add("Aquatic plant");
            referenceNature.Add("Cactus");
            referenceNature.Add("Carnivorous plants");
            referenceNature.Add("Climber plants");
            referenceNature.Add("Tree");

            referenceNature.Sort();
            Console.WriteLine(string.Join("\n", referenceNature));

            Random rnd = new Random();

            int number = rnd.Next(1, 17);
            int number2 = rnd.Next(1, 17);
            int naturenumber = rnd.Next(1, 25);

            Console.WriteLine($"{typegen[number]} {typegen[number2]} {referenceNature[naturenumber]}");

            //Console.WriteLine($"Primary attribute: {typegen[number]}\nSecondary attribute: {typegen[number2]}\nCreature Basis: {referenceNature[naturenumber]}");

            // Floral, Lightning and Canine inspired.

        }

        static void Main(string[] args)
        {
           
            CreatureLibrary skell = new Skell();
            CreatureLibrary ridge = new Ridge();
            CreatureLibrary phase = new Phase();
            /*
            CreatureLibrary clasque = new Clasque();
            CreatureLibrary bufest = new Bufest();
            CreatureLibrary faethiol = new Faethiol();
            CreatureLibrary gazfurn = new Gazfurn();
            CreatureLibrary wuSkurg = new WuSkurg();
            CreatureLibrary myrthra = new Myrthra();
            CreatureLibrary flit = new Flit();
            CreatureLibrary aezalor = new Aezalor();
            CreatureLibrary bracer = new Bracer();
            */
            int someClassCount = InstanceCounter<CreatureLibrary>.Count;
            List<CreatureLibrary> TotalList = new List<CreatureLibrary>();

            TotalList.Add(skell); TotalList.Add(ridge); TotalList.Add(phase);

            Catalogue Catalogue = new Catalogue(someClassCount, TotalList);

        }
       
    }
     
}

