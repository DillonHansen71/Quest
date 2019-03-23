using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Models;

namespace Quest.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Returns a player that matches the currently logged on users Email
        [Authorize]
        public async Task<IActionResult> Index(int? id)
        {
            string email = User.Identity.Name;
            Player selectedPlayer = null;

            //return View(await _context.Player.ToListAsync());
            //only returns the player object that matched the email if the person logged in
            //Player players = await _context.Player.ToListAsync();
            var players = await _context.Player.ToListAsync();
            
            //Find the player object with the matching email
            foreach (Player player in players)
            {
                if(player.Email == email)
                {
                    //return View(player);
                    selectedPlayer = player;
                }
            }
            if(selectedPlayer == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(selectedPlayer);
        }
        //GET: All Inventories
        public async Task<IActionResult> AllInventories()
        {
            var inventories = await _context.Inventory.ToListAsync();
            return View("AllPlayers", inventories);
        }


        // GET: All Players
        public async Task<IActionResult> AllPlayers()
        {
            return View(await _context.Player.ToListAsync());
        }

        // GET: Players/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Health,Attack")] Player player)
        {
            // Make the player
            if (ModelState.IsValid)
            {
                player.Email = User.Identity.Name;
                _context.Add(player);
                await _context.SaveChangesAsync();

                //Find the player that was just created with the matching email of the logged on user
                string email = User.Identity.Name;
                Player selectedPlayer = null;
                var players = await _context.Player.ToListAsync();
                foreach (Player p in players)
                {
                    if (p.Email == email)
                    {
                        selectedPlayer = p;
                    }
                }

                //Create the Inventory for the player
                Inventory inventory = new Inventory();
                inventory.PlayerID = selectedPlayer.ID;
                selectedPlayer.Inventory = inventory;
                _context.Add(inventory);
                _context.Update(selectedPlayer);
                await _context.SaveChangesAsync();

                //Get the updated player object from the database, this will contain the Inventory.ID
                players = await _context.Player.ToListAsync();
                foreach (Player p in players)
                {
                    if (p.Email == email)
                    {
                        selectedPlayer = p;
                    }
                }

                //Create one item to add to the inventory
                Item item = new Item();
                item.Name = "Rusty Sword";
                item.Type = "Weapon";
                item.Damage = 1;
                item.Value = 5;
                item.ItemImage = "path";

                //Add the item to the database
                item.InventoryID = selectedPlayer.Inventory.ID;
                _context.Add(item);
                await _context.SaveChangesAsync();
                
                //Find the newly created inventory that was attached to the newly created player
                var inventories = await _context.Inventory.ToListAsync();
                Inventory selectedInventory = null;
                foreach (Inventory I in inventories)
                {
                    if (I.ID == selectedPlayer.Inventory.ID)
                    {
                        selectedInventory = I;
                    }
                }
                //Add the item to the inventory
                selectedInventory.Items.Add(item);
                //save the changes
                _context.Update(selectedInventory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Health,Attack,ProfileImage")] Player player)
        {
            if (id != player.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.ID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.ID == id);
        }
    }
}
