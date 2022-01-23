using System;
using UnityEngine;

namespace Unity.CreateWithCode.Gameplay
{
   public class ProductivityUnit : Unit
   {
      public float ProductivityMultiplier = 2f;
      private ResourcePile m_CurrentPile = default;

      protected override void BuildingInRange()
      {
         if (m_CurrentPile == null)
         {
            ResourcePile pile = m_Target as ResourcePile;
            if (pile != null)
            {
               Debug.Log("Close to pile");
               m_CurrentPile = pile;
               m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
         }
      }

      public override void GoTo(Building target)
      {
         ResetProductivity();
         base.GoTo(target);
      }

      public override void GoTo(Vector3 position)
      {
         ResetProductivity();
         base.GoTo(position);
      }

      public override string GetName()
      {
         return "Productivity Unit";
      }

      public override string GetData()
      {
         return $"Boosts the production capacity of resource piles.";
      }

      private void ResetProductivity()
      {
         if (m_CurrentPile != null)
         {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
         }
      }
   }
}