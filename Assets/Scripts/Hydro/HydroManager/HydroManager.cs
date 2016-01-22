﻿using UnityEngine;

public class HydroManager : Singleton<HydroManager>
{
    [SerializeField]
    private bool showGizmos;

    [SerializeField]
    [Range(0, 10)]
    private float deformability;
    public static float Deformability
    {
        get
        {
            return Instance.deformability;
        }
    }

    [SerializeField]
    [Range(-10, 10)]
    private float ambientTemperatureChange;
    public static float AmbientTemperatureChange
    {
        get
        {
            return Instance.ambientTemperatureChange;
        }
    }

    [SerializeField]
    private float maximumTemperature;
    public static float MaximumTemperature
    {
        get
        {
            return Instance.maximumTemperature;
        }
    }

    [SerializeField]
    private float vaporizationPoint;
    public static float VaporizationPoint
    {
        get
        {
            return Instance.vaporizationPoint;
        }
    }

    [SerializeField]
    private float minimumEnergyLevel;
    public static float MinimumEnergyLevel
    {
        get
        {
            return Instance.minimumEnergyLevel;
        }
    }

    [SerializeField]
    private float maximumEnergyLevel;
    public static float MaximumEnergyLevel
    {
        get
        {
            return Instance.maximumEnergyLevel;
        }
    }

    [SerializeField]
    private float energyLevelDeviation;
    public static float EnergyLevelDeviation
    {
        get
        {
            return Instance.energyLevelDeviation;
        }
    }

    [SerializeField]
    private LiquidProperties liquidProperties;
    public static LiquidProperties LiquidProperties
    {
        get
        {
            return Instance.liquidProperties;
        }
    }

    [SerializeField]
    private VaporProperties vaporProperties;
    public static VaporProperties VaporProperties
    {
        get
        {
            return Instance.vaporProperties;
        }
    }

    [SerializeField]
    private CloudProperties cloudProperties;
    public static CloudProperties CloudProperties
    {
        get
        {
            return Instance.cloudProperties;
        }
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos)
            return;

        float mapAdjustmentY = MapManager.Map.Height / 2;
        float mapAdjustmentX = MapManager.Map.Width / 2;

        Gizmos.color = new Color(0F, 0.2F, 1F, 0.8F);
        Gizmos.DrawLine(new Vector2(mapAdjustmentX, CloudProperties.CloudLevelUpperBound - mapAdjustmentY), new Vector2(-mapAdjustmentX, CloudProperties.CloudLevelUpperBound - mapAdjustmentY));
        Gizmos.DrawLine(new Vector2(mapAdjustmentX, CloudProperties.CloudLevelLowerBound - mapAdjustmentY), new Vector2(-mapAdjustmentX, CloudProperties.CloudLevelLowerBound - mapAdjustmentY));

        Gizmos.color = new Color(0F, 0.4F, 0.8F, 0.8F);
        Gizmos.DrawLine(new Vector2(mapAdjustmentX, CloudProperties.EquilibriumZoneUpperBound - mapAdjustmentY), new Vector2(-mapAdjustmentX, CloudProperties.EquilibriumZoneUpperBound - mapAdjustmentY));
        Gizmos.DrawLine(new Vector2(mapAdjustmentX, CloudProperties.EquilibriumZoneLowerBound - mapAdjustmentY), new Vector2(-mapAdjustmentX, CloudProperties.EquilibriumZoneLowerBound - mapAdjustmentY));
    }
}