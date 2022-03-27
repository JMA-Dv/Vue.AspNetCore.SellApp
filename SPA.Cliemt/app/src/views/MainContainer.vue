<template>
  <div id="app">
    <section class="hero is-info is-large">
      <Header />
      

      <div class="hero-body">
        <div class="container has-text-centered">
        <router-view/>
        </div>
      </div>

      <Footer/>
    </section>
  </div>
</template>

<script>
import Footer from '@/components/static/Footer.vue'
import Header from '@/components/static/Header.vue'
export default {
  data() {
    return {};
  },
  components:{
      Header,
      Footer
  }
};
</script>
