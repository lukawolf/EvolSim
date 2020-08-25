using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace EvolSim.Creature
{
    /// <summary>
    /// Renders a brain
    /// </summary>
    public static class BrainRenderer
    {
        static readonly Brush[] brushes = new Brush[256];
        static readonly Pen[] pens = new Pen[256];
        static readonly int nodeSpacing = 4;
        //Since we need a given amount of brushes, we pregenerate them
        static BrainRenderer()
        {
            for (int i = 0; i < 256; i++)
            {
                brushes[i] = new SolidBrush(Color.FromArgb(i, 0, 0, 0));
                pens[i] = new Pen(brushes[i]);
            }
        }
        /// <summary>
        /// Prepares a buffer to render the Brain neural network instance, renders into said buffer and then renders the buffer onto the event graphics.
        /// </summary>
        /// <param name="brain">The brain to be rendered</param>
        /// <param name="paintEventArgs">Paint event arguments of the painting target</param>
        public static void RenderBuffered(Brain brain, PaintEventArgs paintEventArgs)
        {
            Image buffer = new Bitmap(paintEventArgs.ClipRectangle.Width, paintEventArgs.ClipRectangle.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(buffer);
            graphics.Clear(Color.White);
            var newArgs = new PaintEventArgs(graphics, paintEventArgs.ClipRectangle);
            Render(brain, newArgs);
            graphics.Dispose();
            paintEventArgs.Graphics.DrawImage(buffer, 0, 0);
            buffer.Dispose();
        }

        /// <summary>
        /// Renders the Brain neural network instance.
        /// </summary>
        /// <param name="brain">The brain to be rendered</param>
        /// <param name="paintEventArgs">Paint event arguments of the painting target</param>
        /// <param name="normaliseNodeSizes">Whether to use the lowest common computed node size. Defaults to true</param>
        private static void Render(Brain brain, PaintEventArgs paintEventArgs, bool normaliseNodeSizes = true)
        {
            if (brain == null)
            {
                throw new ArgumentNullException("Brain can not be null");
            }            
            if (paintEventArgs == null)
            {
                throw new ArgumentNullException("PaintEventArgs can not be null");
            }
            if (!brain.Generated)
            {
                //Ungenerated brain does not get rendered
                return;
            }

            //We calculate all the node widths 
            var inputNodeWidth = paintEventArgs.ClipRectangle.Width / brain.inputNeurons.Length - nodeSpacing;
            if (inputNodeWidth < 1)
            {
                throw new ArgumentException("Rendering field is not wide enough!");
            }
            var thinkingNodeWidth = paintEventArgs.ClipRectangle.Width / brain.thinkingNeurons.Length - nodeSpacing;
            if (thinkingNodeWidth < 1)
            {
                throw new ArgumentException("Rendering field is not wide enough!");
            }
            var outputNodeWidth = paintEventArgs.ClipRectangle.Width / brain.outputNeurons.Length - nodeSpacing;
            if (outputNodeWidth < 1)
            {
                throw new ArgumentException("Rendering field is not wide enough!");
            }
            if (normaliseNodeSizes)
            {
                inputNodeWidth = Math.Min(Math.Min(inputNodeWidth, thinkingNodeWidth), outputNodeWidth);
                thinkingNodeWidth = inputNodeWidth;
                outputNodeWidth = thinkingNodeWidth;
            }

            //We calculate the vertical space we have for synapses
            var verticalSpacing = (paintEventArgs.ClipRectangle.Height - inputNodeWidth - thinkingNodeWidth - outputNodeWidth) / 2;
            if (verticalSpacing < nodeSpacing)
            {
                throw new ArgumentException("Rendering field is not tall enough!");
            }

            //The vertical centers of rows do not change, we can precalculate them for rendering synapses
            var inputNodeVerticalCenter = inputNodeWidth / 2;
            var thinkingNodeVerticalCenter = inputNodeWidth + verticalSpacing + thinkingNodeWidth / 2;
            var outputNodeVerticalCenter = inputNodeWidth + verticalSpacing + thinkingNodeWidth + verticalSpacing + outputNodeWidth / 2;

            //We render each layer with its synapses, weights and output strengths are matched to alpha
            for (int i = 0; i < brain.inputNeurons.Length; i++)
            {
                paintEventArgs.Graphics.FillEllipse(brushes[(int)(brain.inputNeurons[i].Output * 255)], i * (inputNodeWidth + nodeSpacing), 0, inputNodeWidth, inputNodeWidth);
                foreach (var outputParameter in brain.inputNeurons[i].OutputParameters(brain.thinkingNeurons))
                {
                    paintEventArgs.Graphics.DrawLine(pens[(int)(outputParameter.Item2 * 255)], i * (inputNodeWidth + nodeSpacing) + (inputNodeWidth + nodeSpacing) / 2, inputNodeVerticalCenter, outputParameter.Item1 * (thinkingNodeWidth + nodeSpacing) + (thinkingNodeWidth + nodeSpacing) / 2, thinkingNodeVerticalCenter);
                }                
            }
            for (int i = 0; i < brain.thinkingNeurons.Length; i++)
            {
                paintEventArgs.Graphics.FillEllipse(brushes[(int)(brain.thinkingNeurons[i].Output * 255)], i * (thinkingNodeWidth + nodeSpacing), inputNodeWidth + verticalSpacing, thinkingNodeWidth, thinkingNodeWidth);
                foreach (var outputParameter in brain.thinkingNeurons[i].OutputParameters(brain.outputNeurons))
                {
                    paintEventArgs.Graphics.DrawLine(pens[(int)(outputParameter.Item2 * 255)], i * (thinkingNodeWidth + nodeSpacing) + (thinkingNodeWidth + nodeSpacing) / 2, thinkingNodeVerticalCenter, outputParameter.Item1 * (outputNodeWidth + nodeSpacing) + (outputNodeWidth + nodeSpacing) / 2, outputNodeVerticalCenter);
                }
            }
            for (int i = 0; i < brain.outputNeurons.Length; i++)
            {
                paintEventArgs.Graphics.FillEllipse(brushes[(int)(brain.outputNeurons[i].Output * 255)], i * (outputNodeWidth + nodeSpacing), inputNodeWidth + verticalSpacing + thinkingNodeWidth + verticalSpacing, outputNodeWidth, outputNodeWidth);
            }
        }
    }
}
