using System;

namespace ArcadeGames
{
    class HangMan
    {
        static readonly string[] easyWords = { "Gold", "Hair", "Army", "Rain", "Ice", "Bed", "Boy", "Iron", "Room", "Rose", "Car", "King", "Shoe", "Kite", "Lamp", "Lion", "Tent", "Lock", "Dog", "Egg", "Van", "Vase", "Wall", "Nail", "Eye", "Wire", "Nest", "Fish", "Flag", "Yak", "Zoo", "Oil", "Gas", "Girl", "Try", "Call", "Move", "Pay", "Let", "Turn", "Ask", "Buy", "Hold", "Main", "Cook", "Cold", "Low", "Deal", "Fall", "Talk", "Tell", "Cost", "Glad", "Run", "Due", "Rest", "Safe", "Stay", "Rise", "Walk", "Pick", "Lift", "Mix", "Stop", "Fly", "Gain", "Rich", "Save", "Fail", "Lead", "Meet", "Sell", "Ride", "Wait", "Deep", "Flow", "Hit", "Cry", "Dump", "Push", "Eat", "Fill", "Jump", "Kick", "Pass", "Vast", "Beat", "Burn", "Dark", "Draw", "Fix", "Hire", "Join", "Kill", "Tap", "Win", "Drag", "Pull", "Raw", "Soft", "Wear", "Dead", "Feed", "Sing", "Wish", "Dig", "Hang", "Hunt", "Tie", "Hate", "Sad", "Sick", "Hurt", "Lay", "Swim", "Wash", "Fold", "Grab", "Hide", "Miss", "Roll", "Sink", "Slip", "Calm", "Male", "Mine", "Rush", "Suck", "Bear", "Dare", "Dear", "Kiss", "Neat", "Pop", "Quit", "Rip", "Rub", "Tear", "Wake", "Wrap" };
        static readonly string[] mediumWords = { "Actor", "Grass", "Parrot", "Greece", "Pencil", "Airport", "Guitar", "Piano", "Pillow", "Animal", "Pizza", "Answer", "Planet", "Apple", "Helmet", "Plastic", "Holiday", "Honey", "Potato", "Balloon", "Horse", "Queen", "Banana", "Quill", "Battery", "House", "Beach", "Rainbow", "Beard", "Insect", "Belgium", "River", "Branch", "Island", "Rocket", "Jackal", "Brother", "Jelly", "Camera", "Russia", "Candle", "Jordan", "Juice", "School", "Caravan", "Scooter", "Carpet", "Shampoo", "Cartoon", "Kitchen", "China", "Soccer", "Church", "Knife", "Spoon", "Crayon", "Stone", "Crowd", "Lawyer", "Sugar", "Leather", "Sweden", "Death", "Library", "Teacher", "Denmark", "Lighter", "Diamond", "Dinner", "Lizard", "Disease", "Doctor", "London", "Tomato", "Lunch", "Dream", "Machine", "Traffic", "Dress", "Train", "Easter", "Truck", "Uganda", "Market", "Egypt", "Match", "Energy", "Monkey", "Engine", "Morning", "Vulture", "England", "Evening", "Whale", "Napkin", "Window", "Family", "Needle", "Finland", "Nigeria", "Yacht", "Night", "Flower", "Zebra", "Ocean", "Forest", "Garden", "Orange", "France", "Oxygen", "Oyster", "Glass", "Garage", "Ghost", "Check", "Second", "Single", "Guard", "Offer", "Travel", "Special", "Working", "Whole", "Dance", "Excuse", "Primary", "Worth", "Produce", "Search", "Present", "Spend", "Drive", "Green", "Support", "Remove", "Return", "Complex", "Middle", "Regular", "Reserve", "Leave", "Reach", "Serve", "Watch", "Charge", "Active", "Break", "Visit", "Visual", "Affect", "Cover", "Report", "White", "Beyond", "Junior", "Unique", "Classic", "Final", "Private", "Teach", "Western", "Concern", "Broad", "Maybe", "Stand", "Young", "Heavy", "Hello", "Listen", "Worry", "Handle", "Leading", "Release", "Finish", "Normal", "Press", "Secret", "Spread", "Spring", "Tough", "Brown", "Display", "Shoot", "Touch", "Cancel", "Extreme", "Formal", "Pitch", "Remote", "Total", "Treat", "Abuse", "Deposit", "Print", "Raise", "Sleep", "Advance", "Consist", "Double", "Equal", "Attack", "Claim", "Drink", "Guess", "Minor", "Solid", "Weird", "Wonder", "Annual", "Count", "Doubt", "Forever", "Impress", "Nobody", "Repeat", "Round", "Slide", "Strip", "Whereas", "Combine", "Command", "Divide", "Initial", "March", "Mention", "Smell", "Survey", "Adult", "Brief", "Crazy", "Escape", "Gather", "Prior", "Repair", "Rough", "Scratch", "Strike", "Employ", "Illegal", "Laugh", "Mobile", "Nasty", "Respond", "Royal", "Senior", "Split", "Strain", "Train", "Upper", "Yellow", "Convert", "Crash", "Funny", "Permit", "Quote", "Recover", "Resolve", "Spare", "Suspect", "Sweet", "Swing", "Twist", "Usual", "Abroad", "Brave", "Grand", "Prompt", "Quiet", "Refuse", "Regret", "Reveal", "Shake", "Shift", "Shine", "Steal", "Anybody", "Delay", "Drunk", "Female", "Hurry", "Invite", "Punch", "Reply", "Resist", "Silly", "Smile", "Spell", "Stretch", "Stupid" };
        static readonly string[] hardWords = { "Painting", "Advertisement", "Afternoon", "Ambulance", "Hamburger", "Helicopter", "Portugal", "Australia", "Hospital", "Hydrogen", "Raincoat", "Refrigerator", "Insurance", "Restaurant", "Breakfast", "Jewelry", "Sandwich", "Kangaroo", "Daughter", "Telephone", "Television", "Thailand", "Toothbrush", "Magazine", "Magician", "Manchester", "Eggplant", "Umbrella", "Elephant", "Microphone", "Vegetable", "Motorcycle", "Xylophone", "Notebook", "Football", "Fountain", "Furniture", "Increase", "Individual", "Potential", "Professional", "International", "Alternative", "Following", "Commercial", "Purchase", "Necessary", "Positive", "Creative", "Effective", "Independent", "Original", "Beautiful", "Negative", "Anything", "Familiar", "Official", "Comfortable", "Valuable", "Objective", "Chemical", "Conflict", "Opposite", "Somewhere", "Anywhere", "Internal", "Sensitive", "Constant", "Equivalent", "Spiritual", "External", "Ordinary", "Struggle", "Dependent", "Upstairs", "Concentrate", "Estimate", "Surround", "Brilliant", "Inevitable", "Representative", "Temporary", "Tomorrow", "Yesterday" };

        static string playingWord = String.Empty;
        static char[] playingWordLetters = Array.Empty<char>();

        static readonly string[] hangManStages = { @"
 ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||.-''.
| |/         |/  _  \
| |          ||  `/,|
| |          (\\`_.'
| |         .-`--'.
| |        /Y . . Y\
| |       // |   | \\
| |      //  | . |  \\
| |     ')   |   |   (`
| |          ||'||
| |          || ||
| |          || ||
| |          || ||
| |         / | | \
""""""""""""""""""""|_`-' `-' |""""""|
|""|""""""""""""""\ \       '""|""|
| |        \ \        | |
: :         \ \       : :
. .          `'       . .
", @"
 ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||.-''.
| |/         |/  _  \
| |          ||  `/,|
| |          (\\`_.'
| |         .-`--'.
| |        /Y . . Y\
| |       // |   | \\
| |      //  | . |  \\
| |     ')   |   |   (`
| |          ||'-
| |          ||
| |          ||
| |          ||
| |         / |
""""""""""""""""""""|_`-'     |""""""|
|""|""""""""""""""\ \       '""|""|
| |        \ \        | |
: :         \ \       : :
. .
", @"
 ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||.-''.
| |/         |/  _  \
| |          ||  `/,|
| |          (\\`_.'
| |         .-`--'.
| |        /Y . . Y\
| |       // |   | \\
| |      //  | . |  \\
| |     ')   |   |   (`
| |           -'-
| |
| |
| |
| | 
""""""""""""""""""""|_        |""""""|
|""|""""""""""""""\ \       '""|""|
| |        \ \        | |
: :         \ \       : :
. .
", @"
 ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||.-''.
| |/         |/  _  \
| |          ||  `/,|
| |          (\\`_.'
| |         .-`--'.
| |        /Y . . /
| |       // |   |
| |      //  | . |
| |     ')   |   |
| |           -'-
| |
| |
| |
| |
""""""""""""""""""""|_        |""""""|
|""|""""""""""""""\ \       '""|""|
| |        \ \        | |
: :         \ \       : :
. .
", @"
 ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||.-''.
| |/         |/  _  \
| |          ||  `/,|
| |          (\\`_.'
| |         .-`--'.
| |         \ . . /
| |          |   |
| |          | . |
| |          |   |
| |           -'-
| |
| |
| |
| |
""""""""""""""""""""|_        |""""""|
|""|""""""""""""""\ \       '""|""|
| |        \ \        | |
: :         \ \       : :
. .
", @"
 ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||.-''.
| |/         |/  _  \
| |          ||  `/,|
| |          (\\`_.'
| |           `--'
| |
| |
| |
| |
| |          
| |
| |
| |
| |
""""""""""""""""""""|_        |""""""|
|""|""""""""""""""\ \       '""|""|
| |        \ \        | |
: :         \ \       : :
. .
", @"
 ___________.._______
| .__________))______|
| | / /      ||
| |/ /       ||
| | /        ||
| |/         ||
| |          ||_
| |          (\_\)
| |           `--'
| |
| |
| |
| |
| |          
| |
| |
| |
| |
""""""""""""""""""""|_        |""""""|
|""|""""""""""""""\ \       '""|""|
| |        \ \        | |
: :         \ \       : :
. .
"

            };
        static int attemptsLeft;

        enum Diff
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }

        static void DrawGame()
        {
            Console.Clear();
            Console.Write(hangManStages[attemptsLeft]);
            Console.Write('\n');
            
            foreach (char ch in playingWordLetters)
            {
                Console.Write($" {ch}");
            }
        }

        static void SetWord(int difficultyNumber)
        {
            playingWordLetters = Array.Empty<char>();
            attemptsLeft = 6;

            string[] wordsList = difficultyNumber == (int)Diff.Easy ? easyWords :
                                 difficultyNumber == (int)Diff.Medium ? mediumWords :
                                 hardWords;
            playingWord = wordsList[new Random().Next(0, wordsList.Length)];

            foreach (char _ in playingWord)
            {
                playingWordLetters = playingWordLetters.Append('_').ToArray();
            }
        }

        static void PlayLetter(char letterPlayed)
        {
            bool letterInWord = false;
            bool letterAlreadyGuessed = false;
            
            for (int chInd = 0; chInd < playingWord.Length; chInd++)
            {
                if (Char.ToLower(playingWord[chInd]) == char.ToLower(letterPlayed)) 
                {
                    letterInWord = true;
                    if (char.ToLower(playingWordLetters[chInd]) != char.ToLower(letterPlayed))
                    {
                        playingWordLetters[chInd] = playingWord[chInd];
                    }
                    else { 
                        letterAlreadyGuessed = true; 
                        break; 
                    }
                }
            }

            if (!letterInWord)
            {
                attemptsLeft--;
            }
            else if (letterAlreadyGuessed)
            {
                Console.WriteLine("You already guess this letter.");
                Thread.Sleep(1500);
            }
        }

        static bool RestartGame(int difficultyNumber, bool win = false)
        {
            while (true)
            {
                Console.WriteLine("\nDo you want to play again?\n");
                Console.WriteLine("1 - Restart game");
                Console.WriteLine("2 - Back to main menu");

                if (int.TryParse(Console.ReadLine(), out int optionChoosed) && optionChoosed < 3 && optionChoosed > 0)
                {
                    if (optionChoosed == 1)
                    {
                        SetWord(difficultyNumber);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                Console.WriteLine("Enter a valid option number.");
                Thread.Sleep(2000);
                
                DrawGame();
                if (win)
                {
                    Console.WriteLine($"\nThe word is {playingWord}, you won!!!");
                }
                else
                {
                    Console.WriteLine($"\nThe word is {playingWord}, you loose.");
                }
            }
        }

        public static void StartGame(int difficultyNumber)
        {
            Console.Clear();

            SetWord(difficultyNumber);

            while (true)
            {
                DrawGame();

                Console.WriteLine("\nEnter a letter: ");
                if (!char.TryParse(Console.ReadLine(), out char letterPlayed) || !Char.IsLetter(letterPlayed))
                {
                    Console.WriteLine("Enter a valid letter.");
                    Thread.Sleep(1500);
                    continue;
                }

                PlayLetter(letterPlayed);

                if (string.Join("", playingWordLetters) == playingWord)
                {
                    DrawGame();
                    Console.WriteLine($"\nThe word is {playingWord}, you won!!!");
                    if (!RestartGame(difficultyNumber,win:true))
                    {
                        break;
                    }
                }
                else if (attemptsLeft == 0) {
                    DrawGame();
                    Console.WriteLine($"\nThe word is {playingWord}, you loose.");
                    if (!RestartGame(difficultyNumber))
                    {
                        break;
                    }
                }
            }
        }
    }
}
