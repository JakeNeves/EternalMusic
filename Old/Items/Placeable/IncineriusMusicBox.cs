using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace EternalMusic.Items.Placeable
{
    public class IncineriusMusicBox : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Incinerius)");
            if (!ModContent.GetInstance<EternalMusicConfig>().originalMusic)
                Tooltip.SetDefault("JakeTEM - Pyronetic Purgatory");
            else
                Tooltip.SetDefault("JakeTEM - Fiery Battler");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.IncineriusMusicBox>();
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(silver: 10);
            item.accessory = true;
        }

    }
}
