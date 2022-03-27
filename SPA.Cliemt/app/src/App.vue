<template>
  <div v-if="hasConfig">
    <MainContainer/>
  </div>
  <div v-else class="hero-body">
    <div class="has-text-centered is-size-5">

      <p>The project is loading</p>
    </div>
  </div>


    

</template>

<script>
import MainContainer from '@/views/MainContainer.vue'
export default {
  components:{
    MainContainer
  },
  mounted(){
    this.init();
  },
  data(){
    return{
      hasConfig:false,
    }

  },
  methods:{
    
    init(){
      let item = localStorage.getItem('config');
      if(!item){

        fetch('/config').then(x=> x.json()).then(x=> {
          localStorage.setItem('config',JSON.stringify(x));
          this.hasConfig = true;
        })
      }else{
        this.hasConfig = true;
      }
    }
  }
}
</script>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
