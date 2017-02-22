using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Matrix_Library_4_5
{
    public class Paint_Plume
    {
        float[] m_positions;
        float[] m_thicknesses;

        public Paint_Plume(float[] positions, float[] thicknesses, bool spaceingInInches)
        {
            m_positions = new float[positions.Length + 2];
            float positionDelta = positions[1] - positions[0];
            m_positions[0] = positions[0] - positionDelta;
            for (int i=0;i<positions.Length;i++)
            {
                m_positions[i + 1] = positions[i];
            }
            m_positions[m_positions.Length - 1] = positions[positions.Length - 1] + positionDelta;
            
            m_thicknesses = new float[thicknesses.Length + 2];
            m_thicknesses[0] = 0;
            for (int i = 0; i < thicknesses.Length;i++ )
            {
                m_thicknesses[i + 1] = thicknesses[i];
            }
            m_thicknesses[m_thicknesses.Length - 1] = 0;
            
            if (spaceingInInches)
            {
                for (int i = 0; i < m_thicknesses.Length; i++)
                {
                    m_thicknesses[i] *= 25.4f;
                }
            }
        }

        public float getThickness(float position)
        {
            if (position < m_positions[0] || position > m_positions[m_positions.Length - 1])
                return 0;
            else
            {
                for (int i=1;i<m_positions.Length;i++)
                {
                    if (m_positions[i - 1] <= position && position <= m_positions[i])
                    {
                        float lineSlopBetweenKnownMeasurements = (m_thicknesses[i] - m_thicknesses[i - 1]) / (m_positions[i] - m_positions[i - 1]);
                        float b = m_thicknesses[i] - (m_positions[i] * lineSlopBetweenKnownMeasurements);
                        float answer = lineSlopBetweenKnownMeasurements * position + b;
                        if (answer >= 0)
                            return answer;
                        else
                            return 0; 
                    }
                }
                return 0;
            }
        }

        public Paint_Plume Combine(Paint_Plume otherPlume)
        {
            int minWholeMM = (int)Math.Floor(Math.Min(this.m_positions[0], otherPlume.m_positions[0]));
            int maxWholeMM = (int)Math.Ceiling(Math.Max(this.m_positions[this.m_positions.Length - 1], otherPlume.m_positions[otherPlume.m_positions.Length - 1]));
            float[] combinedPositions = new float[maxWholeMM - minWholeMM + 1];
            float[] combinedThicknesses = new float[maxWholeMM - minWholeMM + 1];
            for (int i=0;i<combinedPositions.Length;i++)
            {
                combinedPositions[i] = minWholeMM + i;
                combinedThicknesses[i] = this.getThickness(combinedPositions[i]) + otherPlume.getThickness(combinedPositions[i]);
            }
            return new Paint_Plume(combinedPositions, combinedThicknesses, false);
        }

        public float[] getPositions()
        {
            return m_positions;
        }

        public float[] getThicknesses()
        {
            return m_thicknesses;
        }
    }
}
