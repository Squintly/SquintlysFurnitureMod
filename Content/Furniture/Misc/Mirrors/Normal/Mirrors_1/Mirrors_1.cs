using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
// Since I'm using this as an example/commented version, it'll include a bunch of stuff this does not actually need, all commented out. Let me know if you want function-specific stuff in here, or if checking out the chairs etc. is enough. 
namespace SquintlysFurnitureMod.Content.Furniture.Misc.Mirrors.Normal.Mirrors_1
{
    [LegacyName("Mirrors")] //This is here because I previously only included the number of variations if they were more than one. This was inconsistent and also made the files appear in a weird order in terms of the overlays and highlights and such, so I changed it to a more standardized version. This snippet allows anyone who has an item in their world from before this change to automatically convert without the item breaking.
    public class Mirrors_1 : ModTile
    {
        public enum StyleID //These are not *technically* necessary for the tiles to work, and I haven't much used it yet, but I find having the list up top and not commented out helps me see immediately what is included in any given file, and since the names of the classes are (somewhat by necessity) not indicative of what they actually include, that's very useful. 
        {
            ImperialMirror, //0
            TatteredMirror, //1
            RepairedMirror, //2
            StoneBrickMirror, //3
            RedBrickMirror, //4
            CinderblockMirror //5
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true; // This tells the game whether the tile is a block or a non-block tile. They're technically both tiles but I find it easier to refer to blocks specifically as blocks, and use tiles to mean only non-block tiles, kind of a rectangle/square situation. 

            Main.tileNoFail[Type] = false; //This makes the tile break immediately without worrying about mining speed and is more a relic of me just copy-pasting everything than actual functional code. 
            Main.tileNoAttach[Type] = true; //This keeps you from being able to build off the tile and is almost always true, unless you're making a block (and if that's the case I have abstracts so don't worry about it)

            TileID.Sets.FramesOnKillWall[Type] = true; //This makes the item break if the wall behind it is destroyed. I have just now remembered I did not add it to some of my wall tiles and will now go do so. 

            Main.tileLavaDeath[Type] = false; //I generally set this to false to provide more creative freedom but am constantly changing my mind so don't be surprised if this is inconsistent. (Also it makes lava destroy the tile, if that wasn't obvious)

            TileID.Sets.DisableSmartCursor[Type] = true; //This keeps the smart cursor from automatically selecting this tile the way it does blocks. 
            //TileID.Sets.HasOutlines[Type] = true; //This would give the tile an outline like chairs, beds, etc. Generally set to false.

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3); //This copies a lot of information from various categories laid out by vanilla/tml. There are a bunch of them, but everything can be overridden so I kind of just use whatever seems closest. Only rule: DO NOT USE THE 4x2 ONE IT IS BROKEN.
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 2; 
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 }; //The number of pixels in each block-sized segment of the tile, not counting padding (which is by default 2). It's 18 for the bottom so the tile blends in better with grass and other uneven blocks. The new[] is theoretically unnecessary, but sometimes the game demands an interger = the height in there for reasons I have not yet 100% understood. NOTE: Vertical bigness extends from the top down.
            //TileObjectData.newTile.CoordinateWidth = 32; //This is for the "big" tiles; note that this doesn't work for anything that isn't 1 tile high/wide, so only 1 highs can be vertically big (Tall), only 1 wides can be horizontally big (Wide), and only 1x1s can be both. NOTE: Horizontal bigness moves outward from the center.
            //TileObjectData.newTile.DrawYOffset = -14; //This moves the tile up to make up for vertical "bigness", so that the bottom of a 32x32 tile is in fact the bottom rather than sunk into the ground. Unnecessary for anything hanging from the top.
            TileObjectData.newTile.Origin = new Point16(0, 0); //This can be adjusted if the placement preview looks weird. I usually keep this in everything because I have not yet developed the skills/bothered to think much about what will actually need it so it's easier to just plonk a number in if it looks weird during testing.

            // THE IMPORTANT SECTION FOR VARIATIONS/PLACEMENT STYLES.
            //NOTE: TML refers to two different things as styles, which is super inconvenient. I prefer the terms placement style (sometimes I'll just use style if I forget), which here would refer to "Imperial Mirror", "Tattered Mirror", etc. Each of these placement styles has two variations, which TML also calls styles or sometimes alternate placements/random styles, depending on function. I'll go into that below.
            TileObjectData.newTile.StyleHorizontal = true; //This tells the game whether PLACEMENT STYLES are oriented horizontally or vertically. I almost always set this to true, even though I usually actually orient the sprite sheet vertically, so I can keep all VARIATIONS on one line to make things more legible.
            //TileObjectData.newTile.StyleWrapLimit = 4; //This tells the game how many PLACEMENT STYLES *and* VARIATIONS there are before the sprite sheet wraps to the next line (if horizontal). I usually make this equal to the number of variations/the style multiplier in order to keep all variants on the same line. These mirrors are actually one of the few files where I don't do that, since there are very few variations and it seems more efficient. This is something I intend to be more consistent with in the future.
            TileObjectData.newTile.StyleMultiplier = 2; //This tells the game how many VARIATIONS there are in a single PLACEMENT STYLE. This includes random variants, left-right placements, and so on. Here it's 2, because there are alternate sprites for placement on walls as well as on surfaces. 
            //TileObjectData.newTile.StyleLineSkip = 1; //This gives you an additional row/column after you hit the StyleWrapLimit. They say in the documentation that this is useful for animation and tile states, and should be set even if wrap limit is not used; I personally find it confusing and unnecessary in most cases and generally do not use it. I have not encountered many problems.
            //TileObjectData.newTile.RandomStyleRange = 2; //This sets how many RANDOM VARIATIONS there are. Here it's zero/disabled, because even though there are 2 variants, they aren't placed randomly, but determined by whether the tile is being placed on a wall or surface.

            TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed; //No placing in lava for you.

            TileObjectData.newTile.AnchorBottom = AnchorData.Empty; //This empties out the existing anchor data I copied from Style3x3 (which defaults to surface placement) so I can customize it. 

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile); //This copies everything we did in TileObjectData, including what was copied, into a new separate thing.
            TileObjectData.newAlternate.AnchorWall = true; //This makes the tile anchor to the wall.
            //TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidBottom, TileObjectData.newTile.Width, 0); //This would make the tile hang underneath blocks. 
            //TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight; //This is used for left/right variations, as with chairs. 
            TileObjectData.addAlternate(1); //This tells the game to start' this alternate on the second sprite 'slot'; if set to 0 it'll repeat the first texture, and if this had random variations, it would be set at the first slot after the random variants. For example, if this had 2 random variants, you'd put the first two (which place on the surface) in the sprite sheet first, than the ones that go on the walls (the alternates) and say the alternate begins at 2. 

            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0); //This puts the anchor data for the default back in; if we didn't empty it and then replace it afterwards, the wall ones would require both a wall and a surface.

            TileObjectData.addTile(Type);
        }

        // Below is what we'd use to enable the "right click to change variation" functionality mirrors do not actually have. Since much of the furniture can't have that functionality (because of chairs/beds using right-click for something else) I decided for consistency that none of the furniture would have it.
        
        //public override bool RightClick(int i, int j) //This tells the game to play a little click noise and activate the toggle tile when the tile has been right clicked. It never needs to change.
        //{
        //    SoundEngine.PlaySound(SoundID.Mech);
        //    ToggleTile(i, j);
        //    return true;
        //}

        //public override void HitWire(int i, int j) //This lets wires also activate the toggle tile. This is not the way ExampleMod does it, but the way ExampleMod does it is complicated and weird and I hate it so we use the campfire code instead. 
        //{
        //    ToggleTile(i, j);
        //}

        //public void ToggleTile(int i, int j)
        //{
        //    Tile tile = Main.tile[i, j];
        //    int topX = i - tile.TileFrameX % 90 / 18; //Change first number depending on the size of each individual 'slot'; i.e., if a tile is 1 block wide, it would be 18.
        //    int topY = j - tile.TileFrameY % 32 / 32; //This does the same as the above but vertically. Here I show how to set up "big" blocks. NOTE: If you are doing a block more than 1 high, the number (thanks to the extra 2 pixels for merging into the floor) won't be evenly divisible by 18. This is fine. Don't worry about it.

        //    if (tile.TileFrameX >= 180) //This code was taken from a tile with left-right placement (specifically W_5x1_B_LR_2), so this tells the game whether the below is for the right placement, or the left placement. It should be 1/2 the total width.
        //    {
        //        short frameAdjustment = (short)(tile.TileFrameX >= 270 ? -90 : 90); //This is what tells the game how far the sprite should move when toggled. Essentially: "If the X cooridnate is greater than or equal to 270 (the start of the farthest left style 'slot) then move left 90 pixels; otherwise, move right 90 pixels. The "move left" should be equal to the total number of pixels, minus one style; this usually makes it the same number as the first, as below. 

        //        for (int x = topX; x < topX + 5; x++) //Change the number according to how many blocks there are.
        //        {
        //            for (int y = topY; y < topY + 1; y++) ///Change the number according to how many blocks there are.
        //            {
        //                Main.tile[x, y].TileFrameX += frameAdjustment; //Leave everything here alone, I do not know how it works, just that it does.

        //                if (Wiring.running)
        //                {
        //                    Wiring.SkipWire(x, y); 
        //                }
        //            }
        //        }
        //    }
        //    else //This is the same as the above, but for the right placement. Here you can see how the first two numbers are the same; the third is also the same, since this came from a tile with only two variations, meaning it just has to swap back and forth between the two, rather than cycle back to the beginning of a longer list.
        //    {
        //        short frameAdjustment = (short)(tile.TileFrameX >= 90 ? -90 : 90);

        //        for (int x = topX; x < topX + 5; x++) // change depending on width
        //        {
        //            for (int y = topY; y < topY + 1; y++) // change height
        //            {
        //                Main.tile[x, y].TileFrameX += frameAdjustment;

        //                if (Wiring.running)
        //                {
        //                    Wiring.SkipWire(x, y);
        //                }
        //            }
        //        }
        //    }

        //    if (Main.netMode != NetmodeID.SinglePlayer)
        //    {
        //        NetMessage.SendTileSquare(-1, topX, topY, 5, 1); //change for width, height
        //    }
        //}

        public static Vector2 TileOffset => Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange); //This is required to make the overlay work. Don't ask me why, I do not understand.

        public static Vector2 TileCustomPosition(int i, int j, Vector2 off = default) => new Vector2(i, j) * 16 - Main.screenPosition - off + TileOffset; //Ditto.

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) //This is how the overlay goes!
        {
            Tile tile = Main.tile[i, j];
            
            if (!TileDrawing.IsVisible(tile)) //So it doesn't show up when it's covered in echo painting
            {
                return;
            }

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange); //This LOOKS to me as though it *should* do the same thing as the Vector2 set before, but for reasons I do not understand it doesn't work unless they're both there.

            int height = tile.TileFrameY == 38 ? 18 : 16; //This helps the game account for the 2 extra pixels in the bottom row. Essentially: If the Y coordinate is equal to 38, then height = 18; otherwise it's 16. THIS IS THE ONLY THING YOU SHOULD EVER HAVE TO CHANGE WHEN MAKING A NEW TILE

            spriteBatch.Draw( //NOTE: YOU SHOULD NEVER, EVER HAVE TO CHANGE ANY OF THE STUFF BELOW. IT SHOULD BE FINE. IF IT IS NOT FINE ASK ME ABOUT IT BECAUSE MANUALLY DRAWING SHIT IS COMPLICATED AND SCARY
                 ModContent.Request<Texture2D>(Texture + "_Overlay").Value, //This allows the overlay to use the same name as the default texture, but with _Overlay added on the end. This way, we don't have to manually set what the texture is every time. I do a similar thing for flames.
                 new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, //This positions the overlay
                 new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), //This says how big the overlay should be
                 Lighting.GetColor(i, j)); //this actually draws the overlay
        }
    }
}