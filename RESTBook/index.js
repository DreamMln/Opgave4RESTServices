const baseUrl = "https://"

Vue.createApp({
    data(){
        return{
            books: [],
            titleToGetBy: "",
            idToGetBy: -1,
            singleBook: null,
            deleteId: 0,
            deleteMessage: "",
            addData: { model: "", title: "", price: 0 },
            addMessage: "",
            updateData: { id: 0, model: "", title: "", price: 0 },
            updateMessage: ""
        }
    },
    methods: {
        getAllBooks(){
            this.helperGetAndShow(baseUrl)
        },
        getByTitle(title){
            const url = baseUrl
        },
    }
})