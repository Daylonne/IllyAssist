using IllyriadAssist.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CodeStyle;

namespace IllyriadAssist.Data
{
    public class DbInitializer
    {
        public static void Initialize(IllyContext context)
        {
            // Check if Rare Minerals has been populated.
            if (context.RareMinerals.Any())
            {
                return; // Rare Minerals Table has been seeded.
            }

            var rareMineralsData = new RareMinerals[]
            {
                // Aeghris
                new RareMinerals
                {ItemName = "Aeghris", IllyCode = "[@c=202]",
                 ItemDescription = "This purple-blue gemstone is associated with the element of Air. Brittle and light-weight, it is sometimes used in jewellery, but is mostly sought out by mages.",
                 ImageName = "aeghris.png"},

                // Almhurin
                new RareMinerals
                {ItemName = "Almhurin", IllyCode = "[@c=205]",
                 ItemDescription = "This green-blue gemstone has had various uses throughout history. Werzelnak Scrumptrick, the legendary Gnome Brewer of the Second Age, was said to stir his vats with a staff encrusted in Almhurin.  King Sigurd's chamberlain insists that the king's clothes be washed in a tub with an Almhurin gem set at its base.  And the leaders of the Lannigolds each drink only from cups with Almhurin-studded rims, which they say keep them safe from poison attempts.",
                 ImageName = "almhurin.png"},
            
                 // Amar Shards
                new RareMinerals
                {ItemName = "Amar Shards", IllyCode = "[@c=211]",
                 ItemDescription = "These irregular, glowing crystals were once highly prized by the Elves of the great empire of Alda Amar. Legend tells that their arch mages hoped that they could release pure Mana from the stones, but that they never perfected the technique; instead, they developed potent spells which relied upon these for their augmented force",
                 ImageName = "amarShards.png"},

                 // Arterium
                new RareMinerals
                {ItemName = "Arterium", IllyCode = "[@c=193]",
                 ItemDescription = "Rarer than iron, but more durable, the Dwarves of the Second Age name this metal after the Artefores (their gods), who they say revealed its secrets to the Dwarves of the First Age.",
                 ImageName = "arterium.png"},

                 // Claristrine
                new RareMinerals
                {ItemName = "Claristrine", IllyCode = "[@c=199]",
                 ItemDescription = "Crystals of unusual purity, perfectly transparent yet with dots of light seeming to dance within them, Clarestrine gems are much sought after for their uses in protective magics. Common superstitions say that to carry such a crystal will protect from accidental injury at work. Illyria's foremost mages have more grandiose uses for the crystals.",
                 ImageName = "claristrine.png"},

                 // Daera
                new RareMinerals
                {ItemName = "Daera", IllyCode = "[@c=203]",
                 ItemDescription = "Daera is rare, but visually unremarkable. Typically occurring in nobly pellets about the size of a human fist, it is dark brown, somewhere between red-brown and black-brown, described by some as being about the colour of highly fertile soil. It is of little interest to jewellers, but considerable interest to mages.",
                 ImageName = "daera.png"},

                 // Deepsilver
                new RareMinerals
                {ItemName = "Deepsilver", IllyCode = "[@c=195]",
                 ItemDescription = "Drawn from the deepest mines, this rare blue-white metal is a vital component in the creation of runic inscriptions.  While many pigments and powders can be used to inscribe common, domestic runes, for wards that are expected to cover an entire settlement more specialist ingredients are required to inscribe runes, and Deepsilver is the key component.",
                 ImageName = "deepsilver.png"},

                 // Earthblood
                new RareMinerals
                {ItemName = "Earthblood", IllyCode = "[@c=194]",
                 ItemDescription = "Some Elven theologians tell that the land of Illyria was once a living, feeling entity upon from whom all other races drew succour. In time, they say, the abuses of these ungrateful races caused the world to grow cold and hard and dead, until, as now, it became a dull, lifeless slab of earth and stone.  These orange-red gemstones, they say, are the last traces of the blood of the earth, the living essence which once flowed through it. Other races sometimes ask if there is a mere myth, or if it is actually true; the thelogians say that the question is meangingless.",
                 ImageName = "earthblood.png"},

                 // Elven Tears
                new RareMinerals
                {ItemName = "Elven Tears", IllyCode = "[@c=200]",
                 ItemDescription = "In the current Age, Elven priests often conduct ceremonies of mourning - not for individual deaths or tragedies, but for the world itself, for all the ignorance and cruelty which besets the lands.  Yet these formal rituals are but shadows of the great, spontaneous mournings of ancient times, and it is said that many Elven hermits, at the end of the First and dawn of the Second Ages, mourned with such purity and passion that their tears could cure the sick, delay the effects of mortal ageing, or protect a person from injury.  Where these hermits lived, near to ancient temples, their tears often fell to the ground and, legend says, froze there. And so today, in the soil around these ancient temples, people might hope to find these opaque crystals, resembling ice but warm to the touch, which are called Elven Tears.  Some wear them as personal charms, as protection against injury or illness, but some mages have found more dramatic protective purposes for these.",
                 ImageName = "elvenTears.png"},

                 // Flektrine
                new RareMinerals
                {ItemName = "Flektrine", IllyCode = "[@c=204]",
                 ItemDescription = "Flektrine is a red gemstone, with tiny grains of gold naturally embedded within it.  It is not unattractive, catching the light prettily, but the superstitious say that it is unlucky to keep it in the home as it increases the chance of house fires. Mages rarely comment on such superstitions, but frequently store their Flektrin supplies submerged in cold water.",
                 ImageName = "flektrine.png"},

                 // Goldstone
                new RareMinerals
                {ItemName = "Goldstone", IllyCode = "[@c=208]",
                 ItemDescription = "Deep blue if viewed in dim light, transforming to a brilliant gold as sunlight falls across it, Goldstone seems to be an impossible stone: if weighed, it is heavier than gold, but if dropped it falls through air no faster than a feather; placed in a small amount of water, it causes the water to expand and grow, as if being created from nething; placed in a small fire, the flames will flare and roar at many times their previous heat.",
                 ImageName = "goldstone.png"},

                 // Iceheart
                new RareMinerals
                {ItemName = "Iceheart", IllyCode = "[@c=210]",
                 ItemDescription = "An iron ore runs in veins through common rock, so Iceheart runs in veins through deep layers of ice. Paler than iron, it is also lighter, and although it is too brittle to forge weapons from it directly, iron weapons can be augmented with Iceheart, often in order to make them lighter.",
                 ImageName = "iceheart.png"},

                 // Night Diamond
                new RareMinerals
                {ItemName = "Night Diamond", IllyCode = "[@c=209]",
                 ItemDescription = "Hard as diamond, cut and worked by gem cutters exactly like diamond, these gems are clearly diamonds. Except that they are as black as midnight.  Few wish to have Night Diamonds about their person.  Some have reported the gems talking to them; many notable owners of Night Diamond jewellery have gone mad or killed themselves.  The Blood Thorn Queen, whose cursed followers became the Dark Elves, was said to have the largest ever Night Diamond mounted atop her staff. In the far south, across the Ocean, are rumours of an Eternal Emperor whose crown is encrusted with Night Diamonds and whose empire is forever blighted.",
                 ImageName = "nightDiamond.png"},

                 // Obsidian
                new RareMinerals
                {ItemName = "Obsidian", IllyCode = "[@c=207]",
                 ItemDescription = "Shards of obsidian can be mined from the earth, generally for use in exotic weaponry. A deep black colour, with purple and white accents, this stone can be shaped to hold a good edge, and is popular in many cultures for ceremonial and sacrificial weaponry.",
                 ImageName = "obsidian.png"},

                 // Pyrestone
                new RareMinerals
                {ItemName = "Pyrestone", IllyCode = "[@c=196]",
                 ItemDescription = "In the last days of Alda Amar, a brotherhood of mages dedicated themselves to the recovery of Pyrestone for the empire's defences.  For this, they were both reviled and revered.  Their efforts allowed the empire to cast great Abjurations to shield their people from Orcish curses.  but the brotherhood could only find the stones by seeking out the funeral sites of ancient communities of mages.  The cremations of these potent magicians, imbued with magics of a strength not seen since the dawn of the Second Age, led to concentrations of magic being absorbed by these stones, the wise rulers of Alda Amar believed. It is from this that these stones, flecked in silver and gold and copper hues, are known as Pyrestones.",
                 ImageName = "pyrestone.png"},

                 // Rainbowstone
                new RareMinerals
                {ItemName = "Rainbowstone", IllyCode = "[@c=198]",
                 ItemDescription = "From whatever angle each Rainbowstone is viewed, it always looks the same - one colour at its centre, and others colous in concentric circles radiating out.  However the stone is turned the colours shift so that it looks the same for the viewer. If the stone is broken open (which renders it useless for magical purposes) all of the colour fades away, leaving chunks of dull, opaque crystal. As the crystal is only found in surface layers of soil at some ancient sites, it has been suggested that Rainbowstones are completely artificial, having been made by magicians around the dawn of the Second Age.",
                 ImageName = "rainbowstone.png"},

                 // Siversoil
                new RareMinerals
                {ItemName = "Silversoil", IllyCode = "[@c=206]",
                 ItemDescription = "In deep underground rivers, a silver scum sometimes forms upon the surface of quiet pools. It looks like algae except that it is a brilliant white and shiny.  It behaves in all ways as a metal, except that it floats on water. Scooped up from the water, it can be worked (with some difficulty) to form jewelry, but it is most sought after by mages for its magic reflecting properties.",
                 ImageName = "silversoil.png"},

                 // Silversteel
                new RareMinerals
                {ItemName = "Silversteel", IllyCode = "[@c=212]",
                 ItemDescription = "In the Second Age, the elite armiers of the Dwarves fought with swords forged of Silversteel.  Stronger than iron, with an edge that never dulls, weapons augmented with Silversteel tips, edges or blades are always of exceptional quality.  Resembling iron in colour, Silversteel can be polished until it reflects as well as any mirror, and legends tell of armies wearing Silversteel Plate armour whose enemies would be dazzled by the sunlight flashing on their armour.",
                 ImageName = "silversteel.png"},

                 // Svelaugh Sand
                new RareMinerals
                {ItemName = "Svelaugh Sand", IllyCode = "[@c=201]",
                 ItemDescription = "Svelaugh Sand can be scraped from underground seams in tiny quantities, a bright yellow powder which can be baked into solid forms. Extremely rare, some profilgate rulers have ordered robes to be made, dyed from this sand, as it can stain cloth an outstanding yellow colour.  Legend tells that in the first age, when Dwarven herdsmen guided their flocks through huge underground caverns, these herdsmen carried rods baked from this sand.  Today, its use is primarily in weaving animal-related enchantments.",
                 ImageName = "svelaughSand.png"},

                 // Daera
                new RareMinerals
                {ItemName = "Trove", IllyCode = "[@c=197]",
                 ItemDescription = "The deep green gemstone is named Trove as a direct translation of its Kobold name. It is commonly sought after by these querulous greenskins, apparently for personal adornment, but for most races its value derives from its magical uses.",
                 ImageName = "trove.png"}

            };

            context.RareMinerals.AddRange(rareMineralsData);
            context.SaveChanges();

            // Check if API Settings have been populated
            if (context.APISettings.Any())
            {
                return; // API Settings Table has been seeded.
            }

            var apiSettingsData = new APISettings[]
            {
                // Notification APISettings
                new APISettings
                {APIType = "Notifications"},

                // InGame Mail APISettings
                new APISettings
                {APIType = "InGame Mail"}
            };
            context.APISettings.AddRange(apiSettingsData);
            context.SaveChanges();
}
    }
}
