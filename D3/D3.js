// Seleccionar elementos del DOM
const input = document.getElementById("dataInput");
const button = document.getElementById("updateButton");
const chart = d3.select("#chart");

// Definir una paleta de colores limitada
const colors = ["#1f77b4", "#ff7f0e", "#2ca02c", "#d62728", "#9467bd"];

// Función para actualizar el gráfico
toggleChart = () => {
    let inputData = input.value.trim();
    if (!inputData) return;
    
    let data = inputData.split(",").map(d => parseInt(d.trim())).filter(d => !isNaN(d));
    if (data.length === 0) {
        alert("Por favor, ingrese números válidos separados por comas.");
        return;
    }
    
    // Limpiar el gráfico previo
    chart.selectAll("*").remove();
    
    let barHeight = 30;
    let width = 300;
    
    let scale = d3.scaleLinear()
                  .domain([0, d3.max(data)])
                  .range([0, width]);
    
    let bars = chart.selectAll(".bar")
                    .data(data)
                    .enter()
                    .append("g")
                    .attr("transform", (d, i) => `translate(0, ${i * barHeight})`);
    
    bars.append("rect")
        .attr("width", d => scale(d))
        .attr("height", barHeight - 5)
        .attr("fill", (d, i) => colors[i % colors.length]);
    
    bars.append("text")
        .attr("x", d => scale(d) - 5)
        .attr("y", barHeight / 2)
        .attr("dy", "0.35em")
        .attr("text-anchor", "end")
        .text(d => d)
        .attr("fill", "white");
};

button.addEventListener("click", toggleChart);
