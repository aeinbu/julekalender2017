const http = require("http");
const readline = require("readline");

const getDistanceFromLatLng = require("./haversine");


http.get("http://fil.nrk.no/yr/viktigestader/verda.txt", (response) => {
	const rl = readline.createInterface({
		input: response,
	});

	hovedsteder = new Map();
	rl.on("line", (line) => {
		let [Landskode, Stadnamn_nynorsk, Stadnamn_bokmål, Stadnamn_engelsk, Geonames_ID, Stadtype_nynorsk, Stadtype_bokmål, Stadtype_engelsk, Landsnamn_nynorsk, Landsnamn_bokmål, Landsnamn_engelsk, Folketal, Lat, Lon, Høgd_over_havet, Lenke_til_nynorsk_XML, Lenke_til_bokmåls_XML, Lenke_til_engelsk_XML] = line.split("\t");
		let distanceFromOslo = getDistanceFromLatLng(Lat, Lon, 59.911491, 10.757933);

		if (Stadtype_bokmål === "Hovedstad") {
			hovedsteder[Stadnamn_bokmål] = {
				// lat: Lat,
				// lon: Lon,
				// distanceFromOslo,
				timeFromOslo: distanceFromOslo / 7274
			};
		}
	});

	rl.on("close", () => {
			let liste = [];
			for (let by in hovedsteder) {
				liste.push({ by, ...hovedsteder[by] });
			}
			let sortertListe = liste.sort((l,r) => l.timeFromOslo - r.timeFromOslo);
			console.log("antall byer i listen", sortertListe.length);
			let resultat = liste.reduce((acc, current) => acc.timeUsed + current.timeFromOslo <= 24
					? { numberOfCities: acc.numberOfCities + 1, timeUsed: acc.timeUsed + current.timeFromOslo * 2 }
					: acc, { numberOfCities: 0, timeUsed: 0 });

			console.log("antall byer: ", resultat.numberOfCities);
			console.log("\nDone!");
		});
	});