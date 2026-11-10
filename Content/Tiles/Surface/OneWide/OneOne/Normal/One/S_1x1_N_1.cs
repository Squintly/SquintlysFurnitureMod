using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Surface.OneWide.OneOne.Normal.One;

[LegacyName("S_1x1_N")]
public class S_1x1_N_1 : ModTile
{
    public enum StyleIDs
    {
        SaltAndPepper,
        SantaHat,
        GingerbreadHouse,
        Snowglobe,
        ToyBlocks,
        ToyBear,
        ToyHeartBear,
        Sponge,
        Detergent,
        Waterbottle
    }

    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        TileID.Sets.DisableSmartCursor[Type] = true;

        Main.tileLavaDeath[Type] = false;

        Main.tileNoFail[Type] = false;
        Main.tileNoAttach[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);

        TileObjectData.newTile.CoordinateHeights = new int[1] { 18 };

        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.Table, TileObjectData.newTile.Width, 0);

        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;

        TileObjectData.newTile.StyleHorizontal = true;

        TileObjectData.addTile(Type);

        RegisterItemDrop(Mod.Find<ModItem>("SaltandPepper").Type, 0);
    }
}