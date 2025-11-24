window.plotHappinessMap = (geojson, data) => {

    const locations = data.map(d => d.NeighborhoodName);
    const zValues = data.map(d => d.HappinessScore);

    const trace = {
        type: "choroplethmapbox",
        geojson: geojson,
        locations: locations,
        z: zValues,
        featureidkey: "properties.nhood",
        colorscale: [
            [0.0, "#dc3545"],  // danger red (<0.30)
            [0.30, "#dc3545"],

            [0.30, "#ffc107"],  // warning yellow (0.30–0.40)
            [0.40, "#ffc107"],

            [0.40, "#198754"],  // success green (≥0.40)
            [1.0, "#198754"]
        ],
        zmin: 0,
        zmax: 1,
        marker: { line: { width: 0 } }
    };

    const layout = {
        mapbox: {
            style: "carto-positron",
            center: { lat: 37.76, lon: -122.44 },
            zoom: 10
        },
        margin: { r: 0, t: 0, l: 0, b: 0 }
    };

    Plotly.newPlot("mapDiv", [trace], layout);
};
