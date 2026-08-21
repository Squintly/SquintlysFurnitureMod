//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using ReLogic.Content;
//using Terraria;
//using Terraria.ID;
//using Terraria.GameContent;
//using Terraria.ModLoader;
//using SquintlysFurnitureMod.Content.Blocks.General.Grass;
//using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;

//namespace SquintlysFurnitureMod.Content.Tiles.Plants.Trees.Teak;

//public abstract class TeakTree : ModTree
//{
//    private Asset<Texture2D> texture;
//    private Asset<Texture2D> branchesTexture;
//    private Asset<Texture2D> topsTexture;
//    public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
//    {
//        UseSpecialGroups = true,
//        SpecialGroupMinimalHueValue = 11f / 72f,
//        SpecialGroupMaximumHueValue = 0.25f,
//        SpecialGroupMinimumSaturationValue = 0.88f,
//        SpecialGroupMaximumSaturationValue = 1f
//    };
//    public override void SetStaticDefaults()
//    {
//        GrowsOnTileId = [ModContent.TileType<TeakGrassBlock>()];
//        texture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Plants/Trees/Teak/TeakTree");
//        branchesTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Plants/Trees/Teak/TeakTreeBranches");
//        topsTexture = ModContent.Request<Texture2D>("SquintlysFurnitureMod/Content/Tiles/Plants/Trees/Teak/TeakTreeTops");

//    }
//    public override Asset<Texture2D> GetTexture()
//    {
//        return texture;
//    }
//    public override int SaplingGrowthType(ref int style) {
//		style = 0;
//		return ModContent.TileType<TeakSapling>();
//	}

//	public override void SetTreeFoliageSettings(int i, int j, Tile tile, int xoffset, ref int treeFrame, int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight) {
//		// This is where fancy code could go, but let's save that for an advanced example
//	}

//	// Branch Textures
//	public override Asset<Texture2D> GetBranchTextures() => branchesTexture;

//	// Top Textures
//	public override Asset<Texture2D> GetTopTextures() => topsTexture;

//	public override int DropWood() {
//		return ModContent.ItemType<TeakWood>();
//	}

//	public override bool Shake(int x, int y, ref bool createLeaves) {
//		Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ModContent.ItemType<TeakWood>());
//		return false;
//	}

//	public override int TreeLeaf() {
//		return ModContent.GoreType<TeakLeaf>();
//	}
//}