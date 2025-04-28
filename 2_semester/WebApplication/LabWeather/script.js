let weatherData = [];
let currentIndex = 0;

const weatherIcons = {
    0: "☀️", 1: "🌤️", 2: "⛅", 3: "☁️", 45: "🌫️", 48: "🌫️",
    51: "🌦️", 53: "🌧️", 55: "🌧️", 61: "🌧️", 63: "🌧️", 65: "🌧️",
    71: "🌨️", 73: "🌨️", 75: "🌨️", 95: "⛈️", 96: "⛈️", 99: "⛈️"
};

async function fetchWeather() {
    try {
        const response = await fetch(`https://api.open-meteo.com/v1/forecast?latitude=55.03&longitude=82.92&daily=temperature_2m_max,temperature_2m_min,precipitation_sum,weathercode,windspeed_10m_max,sunrise,sunset,daylight_duration&hourly=relativehumidity_2m&timezone=auto`); 
        const data = await response.json();
        weatherData = data.daily;
        
        weatherData.humidity = [];
        for (let i = 0; i < data.hourly.time.length; i++) {
            const date = new Date(data.hourly.time[i]).toLocaleDateString();
            if (!weatherData.humidity[date]) {
                weatherData.humidity[date] = [];
            }
            weatherData.humidity[date].push(data.hourly.relativehumidity_2m[i]);
        }

        currentIndex = 0;
        showWeather();
    } catch (error) {
        document.querySelector('.weather-wrapper').innerText = 'Ошибка загрузки данных.';
        console.error('Ошибка:', error);
    }
}

function showWeather() {
    if (weatherData.time && weatherData.time.length > 0) {
        const date = new Date(weatherData.time[currentIndex]);
        const options = { weekday: 'long', day: 'numeric', month: 'long' };
        const dateString = date.toLocaleDateString('ru-RU', options);

        const tempMax = weatherData.temperature_2m_max[currentIndex];
        const tempMin = weatherData.temperature_2m_min[currentIndex];
        const wind = weatherData.windspeed_10m_max[currentIndex];
        const precipitation = weatherData.precipitation_sum[currentIndex];
        const code = weatherData.weathercode[currentIndex];
        const icon = weatherIcons[code] || "⛅";

        const sunrise = new Date(weatherData.sunrise[currentIndex]);
        const sunset = new Date(weatherData.sunset[currentIndex]);
        const sunriseTime = sunrise.toLocaleTimeString('ru-RU', {hour: '2-digit', minute: '2-digit'});
        const sunsetTime = sunset.toLocaleTimeString('ru-RU', {hour: '2-digit', minute: '2-digit'});
        
        const daylightHours = Math.round(weatherData.daylight_duration[currentIndex] / 3600 * 10) / 10;
        
        
        const humidityData = weatherData.humidity[dateString];
        const avgHumidity = humidityData ? Math.round(humidityData.reduce((a, b) => a + b, 0) / humidityData.length) : 0;
        
        document.getElementById('weather-icon').innerText = icon;
        document.getElementById('temp').innerText = `${tempMax}° / ${tempMin}°`;
        document.getElementById('date').innerText = dateString;
        document.getElementById('precipitation').innerText = `Осадки: ${precipitation} мм`;       
        document.getElementById('wind').innerText = `Ветер: ${wind} м/с`;
        document.getElementById('sunrise').innerText = `Восход: ${sunriseTime}`;
        document.getElementById('sunset').innerText = `Закат: ${sunsetTime}`;
        document.getElementById('daylight').innerText = `Долгота дня: ${daylightHours}ч`;
        
    }
}

function nextDay() {
    currentIndex = (currentIndex + 1) % weatherData.time.length;
    showWeather();
}

function prevDay() {
    currentIndex = (currentIndex - 1 + weatherData.time.length) % weatherData.time.length;
    showWeather();
}

function updateSky() {
    const now = new Date();
    const hours = now.getHours();
    const minutes = now.getMinutes();
    const totalMinutes = hours * 60 + minutes;

    const dayStart = 6 * 60;  // 6:00
    const dayEnd = 18 * 60;   // 18:00

    const sun = document.getElementById('sun');
    const moon = document.getElementById('moon');

    if (totalMinutes >= dayStart && totalMinutes <= dayEnd) {
        // День
        document.body.style.background = "linear-gradient(135deg, #87cefa 0%, #4682b4 100%)"; // светло-голубой
        sun.style.display = "block";
        moon.style.display = "none";

        const percent = (totalMinutes - dayStart) / (dayEnd - dayStart);
        sun.style.left = `${percent * 100}%`;
    } else {
        // Ночь
        document.body.style.background = "linear-gradient(135deg, #0f2027 0%, #203a43 50%, #2c5364 100%)"; // темно-синий
        sun.style.display = "none";
        moon.style.display = "block";

        let nightMinutes;
        if (totalMinutes < dayStart) {
            nightMinutes = totalMinutes + (24 * 60 - dayEnd);
        } else {
            nightMinutes = totalMinutes - dayEnd;
        }
        const nightDuration = (24 * 60) - (dayEnd - dayStart);
        const percent = nightMinutes / nightDuration;
        moon.style.left = `${percent * 100}%`;
    }
}

setInterval(updateSky, 60000); // каждую минуту обновляем
updateSky();
fetchWeather();