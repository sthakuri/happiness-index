window.plotHappinessMap = (elementId, geojson, data) => {

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
            zoom: 11
        },
        margin: { r: 0, t: 0, l: 0, b: 0 }
    };

    Plotly.newPlot(elementId, [trace], layout);
};

window.plotNormalizedAttributes = function (elementId, dataObj) {

    const labels = dataObj.map(d => d.NeighborhoodName);
    const econ = dataObj.map(d => d.EconomicScore);

    const happiness = dataObj.map(d => d.HappinessScore);
    const population = dataObj.map(d => d.Population);

    var data = [{
        x: econ,
        y: happiness,
        mode: 'markers',
        text: labels,
        marker: {
            size: population.map(p => Math.max(p, 1000)),
            color: happiness,
            colorscale: [
                [0.0, "#dc3545"],  // danger red (<0.30)
                [0.30, "#dc3545"],

                [0.30, "#ffc107"],  // warning yellow (0.30–0.40)
                [0.40, "#ffc107"],

                [0.40, "#198754"],  // success green (≥0.40)
                [1.0, "#198754"]
            ],
            cmin: 0,
            cmax: 1,
            sizemode: 'area',
            showscale: true,
            colorbar: {
                title: "Happiness Score"
            }
        }
    }];

    Plotly.newPlot(elementId, data, {
        title: 'Happiness Index – Bubble Chart',
        xaxis: {
            title: 'Income (Normalized)',
            range: [0, 1]
        },
        yaxis: {
            title: 'Happiness Score',
            range: [0, 1]
        },
        hovermode: 'closest',
        height: 550
    });
};

