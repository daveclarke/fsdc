// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
new Vue({
    el: '#vacancies',
    data: {
        locationDd: 0,
        vacancies: [],
        locations: [],
        isLoading: false
    },
    methods: {
        async getVacancies() {
            try {
                this.isLoading = true;
                let result = await axios.get('/vacancies');
                return result.data;
            } catch (error) {
                return [];
            } finally {
                this.isLoading = false;
            }
        }
    },
    filters: {
        moment: function(date) {
            return this.moment(date).format('D MMMM');
        }
    },
    computed: {
        filteredLocations() {
            if (this.locationDd === 0) return this.vacancies;

            return this.vacancies.filter(vac => vac.locationId === this.locationDd);
        }
    },
    async mounted() {
        this.vacancies = await this.getVacancies();
        let locations = this.vacancies.map(v => { return { id : v.locationId, name : v.locationName }; });
        locations = locations.filter((loc, idx, self) => idx === self.findIndex((el) => el.id === loc.id));
        this.locations = [{id:0, name:"All locations"}, ...locations];
    }
});
