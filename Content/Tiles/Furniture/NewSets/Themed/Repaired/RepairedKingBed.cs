﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Repaired;

public class RepairedKingBed : ModTile
{
    public const int NextStyleHeight = 74; //Calculated by adding all CoordinateHeights + CoordinatePaddingFix.Y applied to all of them + 2

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileID.Sets.HasOutlines[Type] = true;
        /*TileID.Sets.CanBeSleptIn[Type] = true; */// Facilitates calling ModifySleepingTargetInfo
        TileID.Sets.InteractibleByNPCs[Type] = true; // Town NPCs will palm their hand at this tile
        TileID.Sets.IsValidSpawnPoint[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair); // Beds count as chairs for the purpose of suitable room creation

        AdjTiles = new int[] { TileID.Beds };

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3); // this style already takes care of direction for us
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.Width = 4;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
        TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);
        TileObjectData.addTile(Type);

        AddMapEntry(new Color(191, 142, 111), Language.GetText("ItemName.Bed"));
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
    {
        return true;
    }

    public override void ModifySmartInteractCoords(ref int width, ref int height, ref int frameWidth, ref int frameHeight, ref int extraY)
    {
        // Because beds have special smart interaction, this splits up the left and right side into the necessary 2x2 sections
        width = 4; // Default to the Width defined for TileObjectData.newTile
        height = 4; // Default to the Height defined for TileObjectData.newTile
        extraY = 2;            //extraY = 0; // Depends on how you set up frameHeight and CoordinateHeights and CoordinatePaddingFix.Y
    }

    public override bool RightClick(int i, int j)
    {
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[i, j];
        int spawnX = i - tile.TileFrameX / 18 + (tile.TileFrameX >= 72 ? 5 : 2);
        int spawnY = j + 2;

        if (tile.TileFrameY % NextStyleHeight != 0)
        {
            spawnY--;
        }

        {
            player.FindSpawn();

            if (player.SpawnX == spawnX && player.SpawnY == spawnY)
            {
                player.RemoveSpawn();
                Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), byte.MaxValue, 240, 20);
            }
            else if (Player.CheckSpawn(spawnX, spawnY))
            {
                player.ChangeSpawn(spawnX, spawnY);
                Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), byte.MaxValue, 240, 20);
            }
        }

        return true;
    }
}