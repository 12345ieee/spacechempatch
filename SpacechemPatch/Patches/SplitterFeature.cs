﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpacechemPatch.Patches
{
    [Decoy("#=qm61udI5e9eXBbc6SfLdQV8XLfOnvNNF7wo86LmUnhyk=")]
    internal sealed class SplitterFeature : AbstractFeature
    {
        [Decoy(".ctor")]
        public SplitterFeature(Reactor reactor) :
            base(null, null, false, null, default(Vector2i))    // This is not the real super call, just here to make the compiler happy.
        {

        }

        [Replaced("#=qWQJ$dMDcjxjokRp8n71Fzg==", Patch.MoreFeaturesInResNetResearch, KeepOriginal = true, NewNameForOriginal = "OriginalRender")]
        public override void Render(SpriteBatch spriteBatch, Vector2i position, ReactorLayer layer, Color color, float zOrder, ImageSize imageSize, bool forDragAndDrop)
        {
            OriginalRender(spriteBatch, position, layer, color, zOrder, imageSize, forDragAndDrop);
            int priority = 1;
            foreach (ReactorMember member in ownerReactor.GetMembers())
            {
                if (member == this)
                {
                    break;
                }
                else if (member is SplitterFeature)
                {
                    priority++;
                }
            }
            RenderPriority(spriteBatch, position, color, zOrder, priority);
        }

        public void OriginalRender(SpriteBatch spriteBatch, Vector2i position, ReactorLayer layer, Color color, float zOrder, ImageSize imageSize, bool forDragAndDrop)
        {

        }
    }
}
