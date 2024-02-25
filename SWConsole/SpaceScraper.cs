// A conventient backend for a SpaceWars scraper
using System.Threading.Task;

using PuppeteerSharp;

namespace SpaceScraper;

// Might have to use event driven architecture

// Everything is protected in case there is a need to extend
// with inheritance
public class Scraper
{
    protected string BaseLink { get; }
    protected string Name { get; }
    protected string Token { get; }

    // TODO: Use proper Puppeteer classes for respective variables
    protected Browser Browser { get; }
    protected Page SpectatorPage { get; }
    protected Page PlayerPage { get; }

    protected List<Ship> AllShips => updateShips();
    public PlayerShip Player { get; }
    RecentMessages List<string> {
        get {
            clearAndUpdateMessages();
            return recentMessages;
        }
    }
    
    public async Scraper(string baseLink, string name)
    {
        BaseLink = baseLink;
        Name = name;
        // TODO: Generate and set token here
        // TODO: Generate browser and pages here
        // Set and make browser with options
        // Set and make SpectatorPage and PlayerPage
    }

    protected List<string> recentMessages;

    // Maybe have a game loop that is consistently updated?
    // Must be able to take user input
    // IDEA: Alternative to gameLoop, just use properties
    // that return what is needed. Could make a more minimal gameLoop
    public void gameLoop()
    {
        // An example of what the loop would look like
        clearAndUpdateMessages();
        detectShipsAndCheckState();
    }

    // Detect ships nearby to make sure there is no external damage
    // or threats nearby
    public void detectShipsAndCheckState()
    {
        
    }
    
    // TODO: Updates the ship with all the other players
    public List<Ship> updateShips()
    {

    }

    // Clears the message queue and updates the state of the scraper
    // using those cleared messages through scraping
    public List<string> clearAndUpdateMessages()
    {
        // If messages is empty, do nothing
    }

    // Uses the vulnerability found in last game
    // Two users can type in each others names
    // and stack up points by just shooting each other
    // IDEA: Maybe use websockets so name does not have to be typed?
    // TODO
    public void flukePoints(string name)
    {
        
    }
}

// Stores information for all ships across the map 
public class Ship(string name, int x, int y)
{
    protected string Name { get; set; } => name;
    protected int X { get; set; } => x;
    protected int Y { get; set; } => y;
    // TODO: Scraper things below
    protected int health { get; set; } // Getter will use the scraper
    protected int shield { get; set; } // Getter will use the scraper
}

// Meant to show attributes of individual player screen
// Could even update using the actual API to give player state
// (would take more requests though)
public class PlayerShip : Ship
{
    
}
