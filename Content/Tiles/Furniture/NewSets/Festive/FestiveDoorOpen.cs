using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Festive;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Festive;

public class FestiveDoorOpen : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileSolid[Type] = false;
        Main.tileLavaDeath[Type] = true;
        Main.tileNoSunLight[Type] = true;
        TileID.Sets.HousingWalls[Type] = true;
        TileID.Sets.HasOutlines[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        TileID.Sets.CloseDoorID[Type] = ModContent.TileType<FestiveDoorClosed>();

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);

        AdjTiles = new int[] { TileID.OpenDoor };
        RegisterItemDrop(ModContent.ItemType<FestiveDoorItem>(), 0);

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Door"));

        TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.OpenDoor, 0));
        TileObjectData.addTile(Type);
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
    {
        return true;
    }

    public override void MouseOver(int i, int j)
    {
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<FestiveDoorItem>();
    }
}