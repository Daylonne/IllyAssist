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

            var apiSettingsData = new APISetting[]
            {
                // Notification APISettings
                new APISetting
                {APIType = "Notifications"},

                // InGame Mail APISettings
                //new APISettings
                //{APIType = "InGame Mail"}
            };
            context.APISettings.AddRange(apiSettingsData);
            context.SaveChanges();

            // Check if Regions have been populated
            if (context.IllyRegions.Any())
            {
                return; // Region Data Table has been seeded.
            }

            var illyRegionsData = new IllyRegions[]
            {
                // Region - The Wastes (1)
                new IllyRegions
                {IllyRegionID = 1, RegionName = "The Wastes"},

                // Region - Kal Tirikan (2)
                new IllyRegions
                {IllyRegionID = 2, RegionName = "Kal Tirikan"},

                // Region - Wolgost (3)
                new IllyRegions
                {IllyRegionID = 3, RegionName = "Wolgost"},

                // Region - Ursor (4)
                new IllyRegions
                {IllyRegionID = 4, RegionName = "Ursor"},

                // Region - Qarossian (5)
                new IllyRegions
                {IllyRegionID = 5, RegionName = "Qarossian"},

                // Region - Windlost (6)
                new IllyRegions
                {IllyRegionID = 6, RegionName = "Windlost"},

                // Region - Tamarin (7)
                new IllyRegions
                {IllyRegionID = 7, RegionName = "Tamarin"},

                // Region - Fremorn (8)
                new IllyRegions
                {IllyRegionID = 8, RegionName = "Fremorn"},

                // Region - Norweld (9)
                new IllyRegions
                {IllyRegionID = 9, RegionName = "Norweld"},

                // Region - Laoshin (10)
                new IllyRegions
                {IllyRegionID = 10, RegionName = "Laoshin"},

                // Region - Ragallon (11)
                new IllyRegions
                {IllyRegionID = 11, RegionName = "Ragallon"},

                // Region - Taomist (12)
                new IllyRegions
                {IllyRegionID = 12, RegionName = "Taomist"},

                // Region - Meilla (13)
                new IllyRegions
                {IllyRegionID = 13, RegionName = "Meilla"},

                // Region - Lucerna (14)
                new IllyRegions
                {IllyRegionID = 14, RegionName = "Lucerna"},

                // Region - Middle Kingdom (15)
                new IllyRegions
                {IllyRegionID = 15, RegionName = "Middle Kingdom"},

                // Region - Norweld (16)
                new IllyRegions
                {IllyRegionID = 16, RegionName = "Norweld"},

                // Region - Keppen (17)
                new IllyRegions
                {IllyRegionID = 17, RegionName = "Keppen"},

                // Region - Tor Carrock (18)
                new IllyRegions
                {IllyRegionID = 18, RegionName = "Tor Carrock"},

                // Region - The Western Realms (19)
                new IllyRegions
                {IllyRegionID = 19, RegionName = "The Western Realms"},

                // Region - Keshalia (20)
                new IllyRegions
                {IllyRegionID = 20, RegionName = "Keshalia"},

                // Region - Perrigor (21)
                new IllyRegions
                {IllyRegionID = 21, RegionName = "Perrigor"},

                // Region - Kul Tar (22)
                new IllyRegions
                {IllyRegionID = 22, RegionName = "Kul Tar"},

                // Region - Kumala (23)
                new IllyRegions
                {IllyRegionID = 23, RegionName = "Kumala"},

                // Region - Lan Larosh (24)
                new IllyRegions
                {IllyRegionID = 24, RegionName = "Lan Larosh"},

                // Region - Arran (25)
                new IllyRegions
                {IllyRegionID = 25, RegionName = "Arran"},

                // Region - Turalia (26)
                new IllyRegions
                {IllyRegionID = 26, RegionName = "Turalia"},

                // Region - Zanpur (27)
                new IllyRegions
                {IllyRegionID = 27, RegionName = "Zanpur"},

                // Region - Elijal (28)
                new IllyRegions
                {IllyRegionID = 28, RegionName = "Elijal"},

                // Region - Azura (29)
                new IllyRegions
                {IllyRegionID = 29, RegionName = "Azura"},

                // Region - Djebeli (30)
                new IllyRegions
                {IllyRegionID = 30, RegionName = "Djebeli"},

                // POSSIBLE START OF BROKEN LANDS CONTINENT REGIONS

                // Region - Region 31 - Ocean
                new IllyRegions
                {IllyRegionID = 31, RegionName = "Region 31 (Ocean)"},

                // Region - Tallimar (32)
                new IllyRegions
                {IllyRegionID = 32, RegionName = "Tallimar"},

                // Region - Larn (33)
                new IllyRegions
                {IllyRegionID = 33, RegionName = "Larn"},

                // Region - Kem (34)
                new IllyRegions
                {IllyRegionID = 34, RegionName = "Kem"},

                // Region - Ferra Ilse (35)
                new IllyRegions
                {IllyRegionID = 35, RegionName = "Ferra Ilse"},

                // Region - Trome (36)
                new IllyRegions
                {IllyRegionID = 36, RegionName = "Trome"},

                // Region - Rill Archipelago (37)
                new IllyRegions
                {IllyRegionID = 37, RegionName = "Rill Archipelago"},

                // Region - Stormstone Island (38)
                new IllyRegions
                {IllyRegionID = 38, RegionName = "Stormstone Island"},

                // Region - Region 39 - Not Named
                new IllyRegions
                {IllyRegionID = 39, RegionName = "Region 39 (Unknown)"},

                // Region - Calumnex (40)
                new IllyRegions
                {IllyRegionID = 40, RegionName = "Calumnex"},

                // Region - Puchuallpa (41)
                new IllyRegions
                {IllyRegionID = 41, RegionName = "Puchuallpa"},

                // Region - Region 42 - Not Named
                new IllyRegions
                {IllyRegionID = 42, RegionName = "Region 42 (Unknown)"},

                // Region - Pamanyallpa (43)
                new IllyRegions
                {IllyRegionID = 43, RegionName = "Pamanyallpa"},

                // Region - Huronire (44)
                new IllyRegions
                {IllyRegionID = 44, RegionName = "Huronire"},

                // Region - Clarien (45)
                new IllyRegions
                {IllyRegionID = 45, RegionName = "Clarien"},

                // Region - Pawanallpa (46)
                new IllyRegions
                {IllyRegionID = 46, RegionName = "Pawanallpa"},

                // Region - Region 47 - Not Named
                new IllyRegions
                {IllyRegionID = 47, RegionName = "Region 47 (Unknown)"},

                // Region - The Poisoned Isle (48)
                new IllyRegions
                {IllyRegionID = 48, RegionName = "The Poisoned Isle"},

                // Region - Glanhad (49)
                new IllyRegions
                {IllyRegionID = 49, RegionName = "Glanhad"},

                // Region - Northmarch (50)
                new IllyRegions
                {IllyRegionID = 50, RegionName = "Northmarch"},

                // Region - Region 51 - Ocean
                new IllyRegions
                {IllyRegionID = 51, RegionName = "Region 51 (Ocean)"},

                // Region - Westmarch (52)
                new IllyRegions
                {IllyRegionID = 52, RegionName = "Westmarch"},

                // Region - Region 53 - Not Named
                new IllyRegions
                {IllyRegionID = 53, RegionName = "Region 53 (Unknown)"},

                // Region - Oarnamly (54)
                new IllyRegions
                {IllyRegionID = 54, RegionName = "Oarnamly"},

                // Region - Region 55 - Not Named
                new IllyRegions
                {IllyRegionID = 55, RegionName = "Region 55 (Unknown)"},

                // Region - Gremont (56)
                new IllyRegions
                {IllyRegionID = 56, RegionName = "Gremont"},

                // Region - Coanhara (57)
                new IllyRegions
                {IllyRegionID = 57, RegionName = "Coanhara"},

                // Region - Lapo's Lua (58)
                new IllyRegions
                {IllyRegionID = 58, RegionName = "Lapo's Lua"},

                // Region - Newlands (59)
                new IllyRegions
                {IllyRegionID = 59, RegionName = "Newlands"},

                // Region - Region 60 - Not Named
                new IllyRegions
                {IllyRegionID = 60, RegionName = "Region 60 (Unknown)"},

                // Region - Aindara (61)
                new IllyRegions
                {IllyRegionID = 61, RegionName = "Aindara"},

                // Region - The Pirate Isles (62)
                new IllyRegions
                {IllyRegionID = 62, RegionName = "The Pirate Isles"},

                // Region - Silbeaur (63)
                new IllyRegions
                {IllyRegionID = 63, RegionName = "Silbeaur"},

                // Region - Fellandire (64)
                new IllyRegions
                {IllyRegionID = 64, RegionName = "Fellandire"},

                // Region - Region 65 - Not Named
                new IllyRegions
                {IllyRegionID = 65, RegionName = "Region 65 (Unknown)"},

                // Region - Vindorel (66)
                new IllyRegions
                {IllyRegionID = 66, RegionName = "Vindorel"},

                // Region - Almenly (67)
                new IllyRegions
                {IllyRegionID = 67, RegionName = "Almenly"},

                // Region - Kormandly (68)
                new IllyRegions
                {IllyRegionID = 68, RegionName = "Kormandly"},

                // Region - The Orken Coast (69)
                new IllyRegions
                {IllyRegionID = 69, RegionName = "The Orken Coast"},

                // Region - Kingslands (70)
                new IllyRegions
                {IllyRegionID = 70, RegionName = "Kingslands"},

                // Region - Farshards (71)
                new IllyRegions
                {IllyRegionID = 71, RegionName = "Farshards"},

                // Region - Shardlands (72)
                new IllyRegions
                {IllyRegionID = 72, RegionName = "Shardlands"},

                // Region - Strendur (73)
                new IllyRegions
                {IllyRegionID = 73, RegionName = "Strendur"},

                // Region - Chulbran (74)
                new IllyRegions
                {IllyRegionID = 74, RegionName = "Chulbran"},

                // Region - Jurgor (75)
                new IllyRegions
                {IllyRegionID = 75, RegionName = "Jurgor"},

                // Region - The Long White (76)
                new IllyRegions
                {IllyRegionID = 76, RegionName = "The Long White"},

                // Region - Unknown Lands (77)
                new IllyRegions
                {IllyRegionID = 77, RegionName = "Unknown Lands"},

            };
            context.IllyRegions.AddRange(illyRegionsData);
            context.SaveChanges();

            // Check if Rare Minerals has been populated.
            if (context.RareHerbs.Any())
            {
                return; // Rare Minerals Table has been seeded.
            }

            var rareHerbData = new RareHerbs[]
            {
                // Ancient Oak
                new RareHerbs
                {ItemName = "Ancient Oak", IllyCode = "[c=246]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/ancientOak.png"},

                // Baleberries
                new RareHerbs
                {ItemName = "Baleberries", IllyCode = "[c=231]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/baleberries.png"},

                // Berbane Leaves
                new RareHerbs
                {ItemName = "Berbane Leaves", IllyCode = "[c=227]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/berbaneLeaves.png"},

                // Brascan Seeds
                new RareHerbs
                {ItemName = "Brascan Seeds", IllyCode = "[@c=250]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/brascanSeeds.png"},

                // Brownback Moss
                new RareHerbs
                {ItemName = "Brownback Moss", IllyCode = "[@c=243]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/brownbackMoss.png"},

                // Desert Flame
                new RareHerbs
                {ItemName = "Desert Flame", IllyCode = "[@c=252]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/desertFlame.png"},

                // Dyallom Gall
                new RareHerbs
                {ItemName = "Dyallom Gall", IllyCode = "[@c=233]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/dyallomGall.png"},

                // Ebony Wood
                new RareHerbs
                {ItemName = "Ebony Wood", IllyCode = "[@c=232]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/ebonyWood.png"},

                // Furzion Seedpod
                new RareHerbs
                {ItemName = "Furzion Seedpod", IllyCode = "[@c=239]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/furzionSeedpod.png"},

                // Giant Palm Leaves
                new RareHerbs
                {ItemName = "Giant Palm Leaves", IllyCode = "[@c=251]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/giantPalmLeaves.png"},

                // Ironstem Root
                new RareHerbs
                {ItemName = "Ironstem Root", IllyCode = "[@c=235]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/ironstemRoot.png"},

                // Larkenwood
                new RareHerbs
                {ItemName = "Larkenwood", IllyCode = "[@c=226]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/larkenwood.png"},

                // Lemonwood Bough
                new RareHerbs
                {ItemName = "Lemonwood Bough", IllyCode = "[@c=225]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/lemonwoodBough.png"},

                // Mabri Fruit
                new RareHerbs
                {ItemName = "Mabri Fruit", IllyCode = "[@c=229]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/mabriFruit.png"},

                // Miner's Bane
                new RareHerbs
                {ItemName = "Miner's Bane", IllyCode = "[@c=236]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/minersBane.png"},

                // Pale Cedar Wood
                new RareHerbs
                {ItemName = "Pale Cedar Wood", IllyCode = "[@c=224]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/paleCedarWood.png"},

                // Punfruit
                new RareHerbs
                {ItemName = "Punfruit", IllyCode = "[@c=230]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/punfruit.png"},

                // Queen's Hair Leaves
                new RareHerbs
                {ItemName = "Queen's Hair Leaves", IllyCode = "[@c=248]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/queensHairLeaves.png"},

                // Rahan Palm Wood
                new RareHerbs
                {ItemName = "Rahan Palm Wood", IllyCode = "[@c=247]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/rahanPalmWood.png"},

                // Rockweed Root
                new RareHerbs
                {ItemName = "Rockweed Root", IllyCode = "[@c=241]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/rockweedRoot.png"},

                // Sharproot
                new RareHerbs
                {ItemName = "Sharproot", IllyCode = "[@c=245]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/sharproot.png"},

                // Silverthorn
                new RareHerbs
                {ItemName = "Silverthorn", IllyCode = "[@c=244]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/silverthorn.png"},

                // Snowbell Flowers
                new RareHerbs
                {ItemName = "Snowbell Flowers", IllyCode = "[@c=237]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/snowbellFlowers.png"},

                // Spidertree Leaves
                new RareHerbs
                {ItemName = "Spidertree Leaves", IllyCode = "[@c=249]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/spidertreeLeaves.png"},

                // Suntree Haft
                new RareHerbs
                {ItemName = "Suntree Haft", IllyCode = "[@c=242]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/suntreeHaft.png"},

                // Toadcap Fungus
                new RareHerbs
                {ItemName = "Toadcap Fungus", IllyCode = "[@c=238]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/toadcapFungus.png"},

                // Vistrok Flower
                new RareHerbs
                {ItemName = "Vistrok Flower", IllyCode = "[@c=240]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/vistrokFlower.png"},

                // Warpwood Shoot
                new RareHerbs
                {ItemName = "Warpwood Shoot", IllyCode = "[@c=234]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/warpwoodShoot.png"},

                // Ysanberries
                new RareHerbs
                {ItemName = "Ysanberries", IllyCode = "[@c=228]",
                 ItemDescription = "",
                 ImageName = "rareHerbs/ysanberries.png"},

            };
            context.RareHerbs.AddRange(rareHerbData);
            context.SaveChanges();

        }
    }
}
