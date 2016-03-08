using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class AABZContextInitializer : DropCreateDatabaseIfModelChanges<AABZContext>
    {
        protected override void Seed(AABZContext context)
        {
            foreach (Category c in categoriesList)
            {
                context.Categories.Add(c);
            }

            foreach (Platform p in plataformsList)
            {
                context.Platforms.Add(p);
            }

            foreach (Product p in productsList)
            {
                context.Products.Add(p);
            }
            
            base.Seed(context);
        }

        private Category[] categoriesList = {
            new Category { Name = "Accessories", isVisible = true },
            new Category { Name = "Consoles", isVisible = true },
            new Category { Name = "Games", isVisible = true }
        };

        private Platform[] plataformsList = {
            new Platform { Name = "Playstation 4", isVisible = true },
            new Platform { Name = "Xbox One", isVisible = true }
        };

        private Product[] productsList = {
                new Product {
                    category="Accessories",
                    plataform = "Playstation 4",
                    name = "DualShock 4 Wireless Controller",
                    description = "The DUALSHOCK4 wireless controller features familiar controls while incorporating new ways to interact with games and other players. Improved dual analog sticks and trigger buttons offer an even greater sense of control, while the capacitive touch pad opens up endless potential for new gameplay possibilities. Experience the evolution of play with the DUALSHOCK4 wireless controller.",
                    price = 47.85,
                    stock = 10,
                    isVisible = true
                },

                new Product {
                    category="Accessories",
                    plataform = "Xbox One",
                    name = "Xbox One Wireless Controller",
                    description = "Experience the unique intensity, precision and comfort of the Xbox One Wireless Controller. Impulse Triggers deliver fingertip vibration feedback, so you can feel every jolt and crash in high definition. Responsive thumbsticks and an enhanced D-pad provide greater accuracy. Plug any compatible headset into the standard 3.5mm stereo headset jack. Works with Xbox One and Windows 10 PCs and Tablets.",
                    price = 51.78,
                    stock = 10,
                    isVisible = true
                },

                new Product {
                    category="Accessories",
                    plataform = "Playstation 4",
                    name = "PlayStation Gold Wireless Stereo Headset",
                    description = "From the biggest booms to the quietest whispers, you'll experience every detail of your favorite games in stunning high fidelity 7.1 virtual surround sound via the PlayStation.4/PlayStation.3/PlayStation. Vita/PC Gold Wireless Stereo Headset. Plus, keep the chatter coming through the hidden noise-canceling microphone, and get access to custom game modes created by developers exclusively for PlayStation. with the Headset Companion App.",
                    price = 79.00,
                    stock = 5,
                    isVisible = true
                },

                new Product {
                    category="Consoles",
                    plataform = "Playstation 4",
                    name = "Sony PlayStation 4 500GB Console",
                    description = "The PlayStation 4 system opens the door to an incredible journey through immersive new gaming worlds and a deeply connected gaming community. PS4 puts gamers first with an astounding launch lineup and over 180 games in development. Play amazing top-tier blockbusters and innovative indie hits on PS4. Developer Inspired, Gamer Focused.",
                    price = 349.00,
                    stock = 50,
                    isVisible = true
                },

                new Product {
                    category="Consoles",
                    plataform = "Xbox One",
                    name = "Xbox One 500GB Console - Gears of War: Ultimate Edition Bundle",
                    description = "Own the Xbox One Gears of War: Ultimate Edition Console Bundle, featuring a full-game download of Gears of War: Ultimate Edition, the Superstar Cole multiplayer skin, and early access to the Gears of War 4 Beta. Experience the original Gears of War rebuilt from the ground up in 1080p, including 60FPS competitive multiplayer with 19 maps and six game modes, and five campaign chapters never released on console.",
                    price = 299.00,
                    stock = 70,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Playstation 4",
                    name = "Assassin's Creed Syndicate",
                    description = "London, 1868. The Industrial Revolution unleashes an incredible age of invention, transforming the lives of millions with technologies once thought impossible. Opportunities created during this period have people rushing to London to engage in this new world, a world no longer controlled by kings, emperors, politicians, or religion, but by a new common denominator: money.\n\nNot everyone is able to enjoy the benefits of this boom, however. Despite fueling the engine of the British Empire, workers’ lives are little more than legalized slavery while the top few percent profit from their labor. Living poor and dying young, the lower class unite in protest as a new kind of family, gangs, who turn to a life in the underworld in their struggle to survive.A struggle, until watchful Assassins come to their side and re-ignite an age-old conflict involving London’s leaders that will echo throughout modern history, from the underground up.\n\nIntroducing Jacob Frye, who with the help of his twin sister Evie, will change the fate of millions in Assassin’s Creed Syndicate.Rise to rally and lead the underworld to break the corrupt stranglehold on London in a visceral adventure filled with action, intrigue, and brutal combat.",
                    price = 39.48,
                    stock = 35,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Playstation 4",
                    name = "Call of Duty: Black Ops III - Standard Edition",
                    description = "INTRODUCING A NEW ERA OF BLACK OPS:\n\nCall of Duty: Black Ops III deploys its players into a future where bio-technology has enabled a new breed of Black Ops soldier. Players are now always on and always connected to the intelligence grid and their fellow operatives during battle. In a world more divided than ever, this elite squad consists of men and women who have enhanced their combat capabilities to fight faster, stronger, and smarter. Every soldier has to make difficult decisions and visit dark places in this engaging, gritty narrative.",
                    price = 37.99,
                    stock = 20,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Playstation 4",
                    name = "FIFA 16 - Standard Edition",
                    description = "FIFA 16 innovates across the entire pitch to deliver a balanced, authentic, and exciting football experience that lets you play your way, and compete at a higher level. And with all new ways to play! \n\nWith innovative gameplay features, FIFA 16 brings Confidence in Defending, Control in Midfield, and gives you the tools to create more Moments of Magic than ever before. Fans new to the franchise, or skilled players looking to improve their game will have a chance to Compete at a Higher Level using the all new FIFA Trainer.Innovation Across the Entire Pitch. New Ways to Play. Compete at a Higher Level.Play Beautiful in FIFA 16.\n\n*Users who have enabled Chat or UGM Restriction on their Sony Entertainment Network account will be unable to access the ''Pro Clubs'' game mode. Additional hardware required for Remote Play. Use of PSN and SEN account are subject to the Terms of Service and User Agreement and applicable privacy policy (see terms at sonyentertainmentnetwork.com/terms-of-service & sonyentertainmentnetwork.com/privacy-policy).\n* Online multiplayer also requires a PlayStationPlus subscription.",
                    price = 40.26,
                    stock = 17,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Playstation 4",
                    name = "Grand Theft Auto V",
                    description = "Grand Theft Auto V for PlayStation 4, Xbox One and PC will feature a range of major visual and technical upgrades to make Los Santos and Blaine County more immersive than ever.\n\nIn addition to increased draw distances and higher resolution, players can expect a range of additions and improvements including: new weapons, vehicles and activities, additional wildlife, denser traffic, new foliage system, enhanced damage and weather effects, and much more.\n\nGrand Theft Auto V for PlayStation 4, Xbox One and PC will also feature enhanced radio selections with over 100 additional new songs and new DJ mixes from returning DJs across the game’s 17 radio stations.\n\nEnhancements to Grand Theft Auto Online include an increased player count, with online play now for up to 30 players on PlayStation 4 and Xbox One. All existing gameplay upgrades and Rockstar-created content released since the launch of Grand Theft Auto Online will also be available for the PlayStation 4, Xbox One and PC with much more to come.\n\nThe current community of Grand Theft Auto Online PlayStation 3 and Xbox 360 players will have the ability to transfer their Grand Theft Auto Online characters and progression to their choice of PlayStation 4, Xbox One or PC.",
                    price = 59.99,
                    stock = 30,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Playstation 4",
                    name = "Uncharted 4: A Thief's End",
                    description = "Uncharted 4: A Thief's End\n\nSeveral years after his last adventure, retired fortune hunter, Nathan Drake, is forced back into the world of thieves. With the stakes much more personal, Drake embarks on a globe-trotting journey in pursuit of a historical conspiracy behind a fabled pirate treasure. His greatest adventure will test his physical limits, his resolve, and ultimately what he's willing to sacrifice to save the ones he loves. ",
                    price = 59.90,
                    stock = 100,
                    isVisible = false
                },

                 new Product {
                    category="Games",
                    plataform = "Xbox One",
                    name = "Assassin's Creed Syndicate",
                    description = "London, 1868. The Industrial Revolution unleashes an incredible age of invention, transforming the lives of millions with technologies once thought impossible. Opportunities created during this period have people rushing to London to engage in this new world, a world no longer controlled by kings, emperors, politicians, or religion, but by a new common denominator: money.\n\nNot everyone is able to enjoy the benefits of this boom, however. Despite fueling the engine of the British Empire, workers’ lives are little more than legalized slavery while the top few percent profit from their labor. Living poor and dying young, the lower class unite in protest as a new kind of family, gangs, who turn to a life in the underworld in their struggle to survive.A struggle, until watchful Assassins come to their side and re-ignite an age-old conflict involving London’s leaders that will echo throughout modern history, from the underground up.\n\nIntroducing Jacob Frye, who with the help of his twin sister Evie, will change the fate of millions in Assassin’s Creed Syndicate.Rise to rally and lead the underworld to break the corrupt stranglehold on London in a visceral adventure filled with action, intrigue, and brutal combat.",
                    price = 39.48,
                    stock = 35,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Xbox One",
                    name = "Call of Duty: Black Ops III - Standard Edition",
                    description = "INTRODUCING A NEW ERA OF BLACK OPS:\n\nCall of Duty: Black Ops III deploys its players into a future where bio-technology has enabled a new breed of Black Ops soldier. Players are now always on and always connected to the intelligence grid and their fellow operatives during battle. In a world more divided than ever, this elite squad consists of men and women who have enhanced their combat capabilities to fight faster, stronger, and smarter. Every soldier has to make difficult decisions and visit dark places in this engaging, gritty narrative.",
                    price = 37.99,
                    stock = 20,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Xbox One",
                    name = "FIFA 16 - Standard Edition",
                    description = "FIFA 16 innovates across the entire pitch to deliver a balanced, authentic, and exciting football experience that lets you play your way, and compete at a higher level. And with all new ways to play! \n\nWith innovative gameplay features, FIFA 16 brings Confidence in Defending, Control in Midfield, and gives you the tools to create more Moments of Magic than ever before. Fans new to the franchise, or skilled players looking to improve their game will have a chance to Compete at a Higher Level using the all new FIFA Trainer.Innovation Across the Entire Pitch. New Ways to Play. Compete at a Higher Level.Play Beautiful in FIFA 16.\n\n*Users who have enabled Chat or UGM Restriction on their Sony Entertainment Network account will be unable to access the ''Pro Clubs'' game mode. Additional hardware required for Remote Play. Use of PSN and SEN account are subject to the Terms of Service and User Agreement and applicable privacy policy (see terms at sonyentertainmentnetwork.com/terms-of-service & sonyentertainmentnetwork.com/privacy-policy).\n* Online multiplayer also requires a PlayStationPlus subscription.",
                    price = 40.26,
                    stock = 17,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Xbox One",
                    name = "Grand Theft Auto V",
                    description = "Grand Theft Auto V for PlayStation 4, Xbox One and PC will feature a range of major visual and technical upgrades to make Los Santos and Blaine County more immersive than ever.\n\nIn addition to increased draw distances and higher resolution, players can expect a range of additions and improvements including: new weapons, vehicles and activities, additional wildlife, denser traffic, new foliage system, enhanced damage and weather effects, and much more.\n\nGrand Theft Auto V for PlayStation 4, Xbox One and PC will also feature enhanced radio selections with over 100 additional new songs and new DJ mixes from returning DJs across the game’s 17 radio stations.\n\nEnhancements to Grand Theft Auto Online include an increased player count, with online play now for up to 30 players on PlayStation 4 and Xbox One. All existing gameplay upgrades and Rockstar-created content released since the launch of Grand Theft Auto Online will also be available for the PlayStation 4, Xbox One and PC with much more to come.\n\nThe current community of Grand Theft Auto Online PlayStation 3 and Xbox 360 players will have the ability to transfer their Grand Theft Auto Online characters and progression to their choice of PlayStation 4, Xbox One or PC.",
                    price = 59.99,
                    stock = 30,
                    isVisible = true
                },

                new Product {
                    category="Games",
                    plataform = "Xbox One",
                    name = "Gears of War 4",
                    description = "Uncharted 4: A Thief's End\n\nSeveral years after his last adventure, retired fortune hunter, Nathan Drake, is forced back into the world of thieves. With the stakes much more personal, Drake embarks on a globe-trotting journey in pursuit of a historical conspiracy behind a fabled pirate treasure. His greatest adventure will test his physical limits, his resolve, and ultimately what he's willing to sacrifice to save the ones he loves. ",
                    price = 59.90,
                    stock = 100,
                    isVisible = false
                }
            };
    }
}