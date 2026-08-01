using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Abstracts.Blocks;
using SquintlysFurnitureMod.Content.Blocks.General.Misc;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Blocks.General.Grass;

public class TeakGrass : SolidGrass
{
    public override void SafeSetStaticDefaults()
    {
        RegisterItemDrop(ModContent.ItemType<TerraPretaItem>());
        AddMapEntry(new Color(69, 104, 38));
    }

}

public class TeakGrassSeed : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<TeakGrass>());

        Item.width = 32;
        Item.height = 32;
    }

    public override bool CanUseItem(Player player)
    {
        Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
        if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<TerraPreta>())
        {
            return true;
        }
        return false;
    }

    public override bool? UseItem(Player player)
    {
        int x = Player.tileTargetX;
        int y = Player.tileTargetY;
		Tile tile = Framing.GetTileSafely(x, y);
        if (tile != null && tile.HasTile && tile.TileType == ModContent.TileType<TerraPreta>())
        {
            tile.ResetToType((ushort)ModContent.TileType<TerraPreta>());
            WorldGen.SquareTileFrame(x, y, true);
            if (Main.netMode == 2)
            {
                NetMessage.SendTileSquare(-1, x, y, -1, (TileChangeType)0);
            }
            return true;
        }
        return false;
    }
    public override void AddRecipes()
    {
        CreateRecipe(4)
           .AddIngredient(ItemID.GrassSeeds, 2)
           .AddIngredient(ModContent.ItemType<TeakWood>(), 2)
           .AddTile(TileID.HeavyWorkBench)
           .Register();
    }
}