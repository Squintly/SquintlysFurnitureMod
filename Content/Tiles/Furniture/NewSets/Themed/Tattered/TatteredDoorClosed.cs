using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Furniture.NewSets.Themed.Tattered;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Furniture.NewSets.Themed.Tattered;

public class TatteredDoorClosed : ModTile
{
    public override void SetStaticDefaults()
    {
        // Properties
        Main.tileFrameImportant[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSolid[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileID.Sets.NotReallySolid[Type] = true;
        TileID.Sets.DrawsWalls[Type] = true;
        TileID.Sets.HasOutlines[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;
        TileID.Sets.OpenDoorID[Type] = ModContent.TileType<TatteredDoorOpen>();

        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);

        AdjTiles = new int[] { TileID.ClosedDoor };

        AddMapEntry(new Color(200, 200, 200), Language.GetText("MapObject.Door"));

        TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.ClosedDoor, 0));
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
        player.cursorItemIconID = ModContent.ItemType<TatteredDoorItem>();
    }
}