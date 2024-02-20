// Brock's custom code
// Idea is vim style modes that allow you to do different things
// Elite Dangerous style combat mode, command mode, normal mode
// Custom bindings and commands

namespace HandlingTypes
{
    enum Modes
    {
        Normal,
        Combat,
        Command
    }
    
    struct NormalBindings
    {
        public NormalBindings(
            ConsoleKey forward,
            ConsoleKey right,
            ConsoleKey left,
            ConsoleKey superRight,
            ConsoleKey superLeft,
            ConsoleKey fire,
            ConsoleKey clearQueue
        ) {
            Forward = forward;
            Right = right;
            Left = left;
            SuperRight = superRight;
            SuperLeft = superLeft;
            Fire = fire;
            ClearQueue = clearQueue;
        }

        public ConsoleKey Forward { get; }
        public ConsoleKey Right { get; }
        public ConsoleKey Left { get; }
        public ConsoleKey SuperRight { get; }
        public ConsoleKey SuperLeft { get; }
        public ConsoleKey Fire { get; }
        public ConsoleKey ClearQueue { get; }
    }

    // Command base, uses a prerequisite key and inputs for the command
    // Void function wrapper for parsing a command
    struct CommandBase
    {
        public CommandBase(ConsoleKey baseKey, Action command)
        {
            BaseKey = baseKey;
            Command = command;
        }

        public ConsoleKey BaseKey { get; }
        public Action Command { get; }
    }

    struct CombatBindings
    {
        public CombatBindings(
            ConsoleKey strafeLeft,
            ConsoleKey strafeRight,
            ConsoleKey clearQueue
        ) {
            StrafeLeft = strafeLeft;
            StrafeRight = strafeRight;
            ClearQueue = clearQueue;
        }

        public ConsoleKey StrafeLeft;
        public ConsoleKey StrafeRight;
        public ConsoleKey ClearQueue;
    }

    class InputHandler
    {
        public InputHandler(
            ConsoleKey combatMode,
            ConsoleKey commandMode,
            ConsoleKey escapeToNormal,
            NormalBindings normalBindings,
            Dictionary<ConsoleKey, Action> commandBindings,
            CombatBindings combatBindings
        ) {
            CombatMode = combatMode;
            CommandMode = commandMode;
            EscapeToNormal = escapeToNormal;
            NormalKeyBindings = NormalKeyBindings;
            CommandKeyBindings = commandBindings;
            CombatKeyBindings = combatBindings;
            Mode = Modes.Normal;
        }
        
        // Individual variables for each of the commands
        public ConsoleKey CombatMode { get; }
        public ConsoleKey CommandMode { get; }
        // Escapes the other modes into normal
        public ConsoleKey EscapeToNormal { get; }
        
        public NormalBindings NormalKeyBindings { get; }
        // Uses a hashmap that runs a function based on command
        public Dictionary<ConsoleKey, Action> CommandKeyBindings { get; }
        public CombatBindings CombatKeyBindings { get; }

        public Modes Mode { get; }
        
        // Runs the function embedded in command mode
        public void HandleCommandMode(ConsoleKey command)
        {
            CommandKeyBindings[command]();
        }
    
        // Display displays the proper commands for the game controller
        public void Display()
        {
            WipeScreenAndResetCursor();

            // Initialize used variables
            int width = Console.WindowWidth;
            int columnWidth;
            // Changes display depending on the mode of the app
            switch(Mode)
            {
                // Normal mode
                case Modes.Normal:
                    // TODO: Implement this into a column display function that takes an array
                    string[] commandsInfo = { 
                        $"^: { NormalKeyBindings.Forward.ToString() }",
                        $"<: { NormalKeyBindings.Left.ToString() }",
                        $">: { NormalKeyBindings.Right.ToString() }",
                        $"Super <: { NormalKeyBindings.SuperLeft.ToString() }",
                        $"Super >: { NormalKeyBindings.SuperRight.ToString() }",
                        $"Fire: { NormalKeyBindings.Fire.ToString() }",
                        $"Clear Queue: { NormalKeyBindings.ClearQueue.ToString() }"
                    };
                    
                    // Gets the max length of the inputed arrays
                    columnWidth = 0;
                    int length;
                    foreach(string commandInfo in commandsInfo)
                    {
                        length = commandInfo.Length;
                        if(length > columnWidth)
                        {
                            columnWidth = length;
                        }
                    }
                    
                    // Displays using column size of the max length of items in the array
                    foreach(string commandInfo in commandsInfo)
                    {
                        string output = String.Format(
                            $"{{0,{columnWidth}}}",
                            commandInfo
                        );

                        if ((Console.GetCursorPosition().Item1 + columnWidth) <= width)
                        {
                            Console.Write(output);
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                    break;
                case Modes.Combat:
                    break;
                case Modes.Command:
                    break;
            }
        }

        public static void WipeScreenAndResetCursor()
        {
            Console.SetCursorPosition(0, 0);
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            for(int i = 0; i < height; i++)
            {
                for(int n = 0; n < width; n++)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
