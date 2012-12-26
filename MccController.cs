using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ka.WinForm;

namespace MapChipCreator
{
	public class MccController : KaController
	{
		protected override void init()
		{
			base.init();

			//var m = model as MccModel;

			bindBlocks();
		}

		// ブロックにイベントを設定
		private void bindBlocks()
		{
			var m = model as MccModel;
			var v = view as MccView;

			var normalImg = m.SampleBlock;
			var overImg = m.SampleBlock_o;
			var blocks = v.blocks;
			foreach ( var block in blocks )
			{
				// マウスオーバーイベント
				block.MouseEnter += ( s, e ) =>
				{
					block.Image = overImg;
				};
				block.MouseLeave += ( s, e ) =>
				{
					block.Image = normalImg;
				};

				// クリックイベント
				block.Click += ( s, e ) =>
				{
					//v.mainForm.Text = block.Location.ToString();
				};
			}
		}
	}
}
