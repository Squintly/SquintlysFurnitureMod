using SquintlysFurnitureMod.Content.Items.Decorations.Misc;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Misc;

public class DecoSpikes : ModTile
{
    public override void SetStaticDefaults()
    {
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileNoFail[Type] = true;
        Main.tileNoAttach[Type] = true;

        Main.tileLavaDeath[Type] = false;
        Main.tileWaterDeath[Type] = false;
        
        Main.tileNoSunLight[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
        TileObjectData.newTile.CoordinatePadding = 2;

        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<DecoSpikeItem>());
    }
}